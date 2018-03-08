using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }
       
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel); 
        }
        [HttpPost]// only apply with httppost not with httpget 
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)//(NewCustomerViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel); 
            }
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // use automapper lib to auto map instead the below 4 lines
                // Mapper.Map(customer,customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
        //[Authorize]
        public ViewResult Index()
        {

            //var customers = _context.Customers.Include(c=> c.MembershipType).ToList();
            // without ToList() the query will execute when the customers var is iterated in View. 
            // ToList will execute the query immediately. 
            if(MemoryCache)
            return View();// (customers);
        }
        /* nolonger needed since the data are queried form db 
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams "}
            };
        }
        */ 

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); // without "New" mvc will look for a view called "Edit" 
        }
    }
}