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

        public ActionResult Index()//主页面
        {
            return View();
        }
       public ActionResult top()//头部
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_true_name;
            return View();
        }
        public ActionResult left()//左边的页面
        {
            return View();
        }
        public ActionResult leftXianshi(HttpContext context)
        {
            string sql = "";
            if (context.Request.Form["id"] == null)
            {
                //查父级
                sql = string.Format(@"select id,text,PermissionsUrl,state from dbo.Permissions q 
inner join(
select PermissionsID from dbo.RolePermissions  where RoleID={0}
)r on q.id=r.PermissionsID
 where MenuID=0
", context.Request.Cookies["id"].Value);
            }
            else
            {
                sql = string.Format(@"select id,text,PermissionsUrl,state from dbo.Permissions q 
inner join(
select PermissionsID from dbo.RolePermissions  where RoleID={0}
)r on q.id=r.PermissionsID
 where MenuID={1}
", context.Request.Cookies["id"].Value, context.Request["id"]);

            }


            DataTable dt = DBHelper.Select(sql, "indexController");
          return  Content(JsonConvert.SerializeObject(dt));

        }
        public ActionResult main()//右边
        {
            return View();
        }
    }
}