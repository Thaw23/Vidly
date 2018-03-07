using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]// data annotation 
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        // navigation property 
        // useful when we want to load an obj and its releated obj together from db 
        
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        
        // [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}