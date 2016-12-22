using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CityService
    {
        public static List<CityServiceInfo> GetAllInfo()
        {
            using (dbContext db=new dbContext())
            {
                return db.ServiceInfos.ToList();
            }
        }
        public static List<CityServiceInfo> GetUsers()
        {
            using (var db = new dbContext())
            {
                return db.ServiceInfos.OrderBy(m => m.Id).ToList();
            }
        }
    }
}
