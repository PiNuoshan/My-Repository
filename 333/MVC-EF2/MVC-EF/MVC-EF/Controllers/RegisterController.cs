using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace MVC_EF.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reg(string userName,string userPwd)
        {
            ComplainRecord user = new ComplainRecord();
            user.Name = userName;
            user.Phone = userPwd;
            user.Info = userPwd;
            user.Phone = userPwd;
            UserManager.AddUser(user);
            return View("Index");
        }
        [HttpPost]
        public ActionResult Create()
        {
            ComplainRecord user = new ComplainRecord();
            user.Name = Request.Params["Name"];
            user.Phone = Request.Params["Phone"];
            user.Info = Request.Params["Info"];
            UserManager.AddUser(user);
            return Redirect("~/UserList/Index");
        }
	}
}