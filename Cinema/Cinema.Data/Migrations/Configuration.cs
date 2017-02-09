using Cinema.Data.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace Cinema.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Cinema.Data.CinemaDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Cinema.Data.CinemaDbContext context)
        {
            if (context.Roles.Count() == 0)
            {
                context.Roles.Add(new IdentityRole("admin"));
                context.Roles.Add(new IdentityRole("user"));
                context.SaveChanges();
            }

            var adminRole = new IdentityUserRole();
            adminRole.RoleId = context.Roles.FirstOrDefault(r => r.Name == "admin").Id;
            context.SaveChanges();

            var adminUser = context.Users.First(u => u.UserName == "Iliyan");
            if (adminUser != null)
            {
                adminUser.Roles.Clear();
                adminUser.Roles.Add(adminRole);
                context.SaveChanges();
            }
        }
    }
}
