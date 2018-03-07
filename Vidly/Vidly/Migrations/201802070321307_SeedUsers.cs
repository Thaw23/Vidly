namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5acca8f9-4559-4519-b2ae-89bcf9d4c1fd', N'admin@vidly.com', 0, N'AOGWtZR/xCzOug0UKbiIK5isyb5Oi1Sd1da+cIy3fQlLBQL7Hb5+lNtLxM4d5ml3/g==', N'b4129377-9a0c-4283-ae82-93df92c6a142', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b8960ad8-f6a2-4bec-b132-4128699e0ec9', N'guest@vidly.com', 0, N'AJdluR6QcXqEMXVmbFo/qX6ENqh07tlQ9VD+YwAyBdBYTVdkRv+I9GEbJzk6mURmVg==', N'23798b56-f598-4d2e-9d74-219bef5ccf9c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'501fa74c-3760-4972-bc77-6b36c2764001', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5acca8f9-4559-4519-b2ae-89bcf9d4c1fd', N'501fa74c-3760-4972-bc77-6b36c2764001')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
