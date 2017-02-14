using Cinema.Data;
using Cinema.Data.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class RolesManagement : System.Web.UI.Page
    {
        [Inject]
        public CinemaDbContext context { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UsersDropdown.DataSource =
                context.Users
                .Where(u => u.UserName != Page.User.Identity.Name)
                .Select(u => u.UserName)
                .ToArray();

            this.UsersDropdown.DataBind();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var adminRole = new IdentityUserRole();
            adminRole.RoleId = this.context.Roles.FirstOrDefault(x => x.Name == "admin").Id;

            var targetUser = this.context.Users.Where(u => u.UserName == this.UsersDropdown.Text).FirstOrDefault();
            targetUser.Roles.Clear();
            targetUser.Roles.Add(adminRole);
            this.context.SaveChanges();
        }

        protected void RemoveAdminButton_Click(object sender, EventArgs e)
        {
            var casherRole = new IdentityUserRole();

            casherRole.RoleId = this.context.Roles.FirstOrDefault(r => r.Name == "casher").Id;

            var targetUser = this.context.Users.Where(u => u.UserName == this.UsersDropdown.Text).FirstOrDefault();
            targetUser.Roles.Clear();
            targetUser.Roles.Add(casherRole);
            this.context.SaveChanges();
        }
    }
}