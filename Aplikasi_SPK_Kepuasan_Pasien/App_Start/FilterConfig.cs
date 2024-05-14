using System.Web;
using System.Web.Mvc;

namespace Aplikasi_SPK_Kepuasan_Pasien
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
