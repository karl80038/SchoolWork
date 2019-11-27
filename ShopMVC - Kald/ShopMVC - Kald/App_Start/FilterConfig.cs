using System.Web;
using System.Web.Mvc;

namespace ShopMVC___Kald
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
