using System.Web;
using System.Web.Mvc;

namespace ESerrano_MVC_EF_Driving
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
