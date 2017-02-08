using System.Web.UI;

namespace Cinema.Data.Services.Contracts
{
    public interface INavigationService
    {
        void Redirect(Page page, string url);
    }
}
