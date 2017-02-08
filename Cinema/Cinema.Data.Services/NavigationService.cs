using Cinema.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Cinema.Data.Services
{
    public class NavigationService : INavigationService
    {
        public void Redirect(Page page, string url)
        {
            page.Response.Redirect(url);
        }
    }
}