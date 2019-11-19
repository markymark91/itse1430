using System.Web;
using System.Web.Mvc;

namespace Itse1430.MovieLib.WebHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters ( GlobalFilterCollection filters )
        {
            filters.Add (new HandleErrorAttribute ());
        }
    }
}
