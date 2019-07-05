using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        IBLL.IUsersBll usersBll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");
        // GET: Login
        public ActionResult Index()
        {
            //添加登录页面
            return View("login");
        }
        public ActionResult Login(users u)
        {
            users user = usersBll.Login(u);
            if (user!=null)
            {
                Session["user"] = user;
                return Content("ok");
            }
            return Content("no");
        }
        public ActionResult Exit()
        {
            Session.Clear();
            return Redirect("Index");
        }
    }
}