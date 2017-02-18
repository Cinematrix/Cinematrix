using Bytes2you.Validation;
using Cinema.Data.Services.Contracts;
using System.Web.UI;

namespace Cinema.Data.Services
{
    public class NavigationService : INavigationService
    {
        public void Redirect(Page page, string url)
        {
            Guard.WhenArgument(page, "page").IsNull().Throw();
            Guard.WhenArgument(url, "url").IsNullOrEmpty().Throw();
            page.Response.Redirect(url);
        }
    }
}