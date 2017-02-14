using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Cinema.Web.Models;
using Cinema.Data.Models;
using Cinema.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Cinema.Data.Repositories;

namespace Cinema.Web.Account
{
    public partial class Register : Page
    {
        CinemaDbContext dbContext = new CinemaDbContext();

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new User() { UserName = Username.Text };

            if (dbContext.Roles.Count() == 0)
            {
                dbContext.Roles.Add(new IdentityRole("admin"));
                dbContext.Roles.Add(new IdentityRole("user"));
                dbContext.Roles.Add(new IdentityRole("casher"));
                dbContext.SaveChanges();
            }

            var userRole = new IdentityUserRole();
            var adminRole = new IdentityUserRole();

            userRole.RoleId = dbContext.Roles.FirstOrDefault(r => r.Name == "user").Id;
            dbContext.SaveChanges();

            adminRole.RoleId = dbContext.Roles.FirstOrDefault(x => x.Name == "admin").Id;
            dbContext.SaveChanges();

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                var usersCount = dbContext.Users.Count();
                var newUser = dbContext.Users.FirstOrDefault(u => u.UserName == Username.Text);
                if (usersCount == 1)
                {
                    newUser.Roles.Add(adminRole);
                    dbContext.SaveChanges();
                }
                else
                {
                    newUser.Roles.Add(userRole);
                    dbContext.SaveChanges();
                }

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}