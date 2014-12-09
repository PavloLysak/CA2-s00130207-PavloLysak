using System.Web;
using System.Web.Mvc;

namespace CA2_PavloLysak_s00130207_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}