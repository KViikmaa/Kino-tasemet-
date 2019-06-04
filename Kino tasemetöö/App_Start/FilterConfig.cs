using System.Web;
using System.Web.Mvc;

namespace Kino_tasemetöö
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
