using System.Web;
using System.Web.Mvc;

namespace Pubsite_VentesB2B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
