using Aplikasi_SPK_Kepuasan_Pasien.Models;
using System.Configuration;
using System.Linq;

namespace Aplikasi_SPK_Kepuasan_Pasien.ViewModels
{
    public class VMLogin
    {
        public string email { get; set; }
        public string password { get; set; }

        readonly DB_SPK_KPGDDataContext db = new DB_SPK_KPGDDataContext(ConfigurationManager.ConnectionStrings["DB_SPK_KPGDConnectionString"].ConnectionString);

        public TBL_T_LOGIN Login()
        {
            var data = db.TBL_T_LOGINs.Where(a => a.email == email & a.password == password).FirstOrDefault();
            return data;
        }
    }
}