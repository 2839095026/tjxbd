using DAO;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        IBLL.IRolesBll role = IocContainer.IocCreate.CreateBll<IBLL.IRolesBll>("RolesBll");
        IBLL.IPermissionsBll ps = IocContainer.IocCreate.CreateBll<IBLL.IPermissionsBll>("PermissionsBll");
        public ActionResult Index()//主页面
        {
            return View();
        }
       public ActionResult top()//头部
        {
            users s = Session["user"] as users;//取值
            ViewBag.user = s.u_true_name;   
            Roles r = role.SelectWhere(s.RoleID).FirstOrDefault();
            ViewBag.userr = r.RoleName;
            return View();
        }
      
        public ActionResult Meuneasyui()
        {
            users s = Session["user"] as users;
            int useId = s.RoleID;
            
            int qxid = 0;
            if (Request.Form["id"]!= null)
            {
                qxid =Convert.ToInt32((Request.Form["id"]));
            }
            DataTable dt = ps.PermissionsAll("indexController", useId,qxid);
            return Content(JsonConvert.SerializeObject(dt)); 
        }
        public ActionResult left()//左边的页面
        {
            return View();
        }
     
        public ActionResult main()//右边
        {
            return View();
        }
    }
}