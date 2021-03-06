﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Linq;

namespace Cinema.Web
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUserName = this.Page.User.Identity.Name;
            string filename = Directory.EnumerateFiles(Server.MapPath("~/UploadedFiles/")).Where(x => x.StartsWith(Server.MapPath("~/UploadedFiles/") + currentUserName)).FirstOrDefault();
            string extension = Path.GetExtension(filename);

            if (this.Page.User.Identity.IsAuthenticated)
            {
                if (File.Exists(Server.MapPath("~/UploadedFiles/") + currentUserName + extension))
                {
                    this.ProfilePicture.ImageUrl = "~/UploadedFiles/" + currentUserName + extension;
                }
            }

            if (!this.Page.User.IsInRole("admin"))
            {
                this.AddFilmScreeningLink.Visible = false;
                this.AddMovieLink.Visible = false;
                this.PaymentLink.Visible = false;
                this.RolesLink.Visible = false;
                this.adminLogo.Visible = false;

                if (this.Page.User.IsInRole("casher"))
                {
                    this.PaymentLink.Visible = true;
                    this.adminLogo.InnerText = "cashier*";
                    this.adminLogo.Visible = true;
                }
            }
            else
            {
                this.AddFilmScreeningLink.Visible = true;
                this.AddMovieLink.Visible = true;

                // this.nav.Style.Add("background-image", "url('http://www.harter.aero/images/banner_admin.png')");
                this.adminLogo.InnerText = "admin*";
                this.adminLogo.Visible = true;
                this.nav.Style.Add("background-size", "30% 100%;");
                this.nav.Style.Add("background-position", "75% 50%");
                this.nav.Style.Add("background-repeat", "no-repeat");
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}