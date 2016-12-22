using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC_EF.Controllers
{
    public class CityServiceInfoController : Controller
    {
        // GET: CityServiceInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SreviceInfo(string keyword, int pageSize = 3, int pageIndex = 1)
        {
            ViewBag.ddl = new SelectList(CityService.GetAllInfo(), "Id", "ServiceInfo");
            List<CityServiceInfo> users = CityService.GetUsers();
            if (string.IsNullOrEmpty(keyword))
            {
                PageHelper.PageList<CityServiceInfo> page = new PageHelper.PageList<CityServiceInfo>(users, pageIndex, pageSize);
                ViewBag.CurrentPage = page.PageIndex;
                ViewBag.PageCount = page.PageCount;
                return View(page);
            }
            else
            {
                return View(UserManager.GetUsersByKey(keyword));
            }
        }
    }
}