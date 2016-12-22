using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace MVC_EF.Controllers
{
    public class UserListController : Controller
    {
        private static bool flag = false;
        //
        // GET: /UserList/
        public ActionResult Index(string keyword, int pageSize = 8, int pageIndex = 1)
        {
            ViewBag.ddl = new SelectList(CityService.GetAllInfo(), "Id", "ServiceInfo");
            List<ComplainRecord> users = UserManager.GetUsers();
            if (string.IsNullOrEmpty(keyword))
            {
                PageHelper.PageList<ComplainRecord> page = new PageHelper.PageList<ComplainRecord>(users, pageIndex, pageSize);
                ViewBag.CurrentPage = page.PageIndex;
                ViewBag.PageCount = page.PageCount;
                return View(page);
            }
            else
            {
                return View(UserManager.GetUsersByKey(keyword));
            }
        }
        public ActionResult Order()
        {
            int pageIndex = 1;
            int pageSize = 3;
            string key = Request.Form["ddl"];
            List<ComplainRecord> users = UserManager.OrderUserByKey(key);
            PageHelper.PageList<ComplainRecord> page = new PageHelper.PageList<ComplainRecord>(users, pageIndex, pageSize);
            ViewBag.CurrentPage = page.PageIndex;
            ViewBag.PageCount = page.PageCount;
            return View("Index",page);
        }
        //public ActionResult Indexx(string keyword, int pageSize = 3, int pageIndex = 1)
        //{ }
        public ActionResult Edit(int id)
        {
            return View(UserManager.GetUserById(id));
        }
        public ActionResult Delete(int id)
        {
            UserManager.DeleteUserById(id);
            return Redirect("~/UserList/Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        
    }
}