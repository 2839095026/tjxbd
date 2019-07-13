using DAO;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using StackExchange.Redis;

namespace UI.Controllers
{
    public class powerController : Controller
    {
        // GET: power   
        IBLL.IUsersBll usersBll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");
        IBLL.IRolesBll role = IocContainer.IocCreate.CreateBll<IBLL.IRolesBll>("RolesBll");
        IBLL.IUsersRolesBll ur = IocContainer.IocCreate.CreateBll<IBLL.IUsersRolesBll>("UsersRolesBll");
        public ActionResult user_list()//用户管理的主页
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<users_roles> list = ur.FenYe(index, 1, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;

            return View(list);
        }
        [HttpGet]
        public ActionResult user_edit(int id)//修改
        {
            ViewBag.st = usersBll.SelectWhere(id).FirstOrDefault();

            List<Roles> list = role.FindAll();

            ViewBag.stt = role.SelectWhere(id).FirstOrDefault();
            return View(list);
        }
        [HttpPost]
        public ActionResult user_edit(users t)
        {
            if (usersBll.Change(t) > 0)
            {
                return Content("<script>alert('修改成功');window.location.href='/power/user_list'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/power/user_list'</script>");
            }
        }
        [HttpGet]
        public ActionResult user_add()//添加
        {
            List<Roles> list = role.FindAll();

            return View(list);
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> user_add(users t)
        {

            if (usersBll.Add(t) > 0)
            {
                using (ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379"))
                {
                    //连接哪个数据库:默认是db0
                    IDatabase db = redis.GetDatabase();

                    users p = new users()
                    {
                        u_name = t.u_name,
                        u_email = t.u_email,
                        u_password = t.u_password
                    };
                    await db.ListLeftPushAsync("d", JsonConvert.SerializeObject(p));

                    RedisValue zhi = await db.ListRightPopAsync("d");
                 Entity.users aa= JsonConvert.DeserializeObject<users>(zhi.ToString());
                    Util.EmailHelper.SendEmail("hr管理系统", "这是你登录这个软件的密码" +aa.u_password, aa.u_email);

                }

                return Content("<script>alert('添加成功');window.location.href='/power/user_list'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/power/user_list'</script>");
            }
        }
        public ActionResult Delete(int id)//删除
        {
            if (usersBll.Del(new users() { u_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>alert('删除成功');window.location.href='/power/user_list'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/power/user_list'</script>");
            }
        }


        public ActionResult right_list()//角色管理的主页
        {

            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<Roles> list = role.FenYe(index, 8, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 8 + 1;
            return View(list);
        }
        [HttpGet]
        public ActionResult right_add()//角色添加
        {
            return View();
        }
        [HttpPost]
        public ActionResult right_add(Roles t)
        {
            if (role.Add(t) > 0)
            {
                return Content("<script>window.location.href='/power/success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/power/right_add'</script>");
            }
        }
        public ActionResult success()//操作成功
        {
            return View();
        }

        public ActionResult right_list_information(int id)
        {
            ViewBag.st = role.SelectWhere(id).FirstOrDefault();
            ViewBag.roleid = id;
            return View();

      
        }//修改的显示
        public ActionResult Handler1()
        {
           
            users s = Session["user"] as users;
        
            string sql = "";
            if (ControllerContext.HttpContext.Request.Form["id"] == null)
            {
                //根节点
                sql = string.Format(@"select p.id,p.text,p.state,case when rp.PermissionsID is null then 0 else 1 end checked  
from dbo.Permissions p left join(
select PermissionsID from dbo.RolePermissions where RoleID={0}
)rp on p.id=rp.PermissionsID where MenuID=0", ControllerContext.HttpContext.Request["rid"]);
            }
            else
            {
                sql = string.Format(@"select p.id,p.text,p.state,case when rp.PermissionsID is null then 0 else 1 end checked  
from dbo.Permissions p left join(
select PermissionsID from dbo.RolePermissions where RoleID={0}
)rp on p.id=rp.PermissionsID where MenuID={1}", ControllerContext.HttpContext.Request["rid"], ControllerContext.HttpContext.Request.Form["id"]);
            }
            DataTable dt = DBHelper.Select(sql, "Handler1");
            return Content(JsonConvert.SerializeObject(dt));
        }//修改显示文件夹

        public  ActionResult UpdateRole(Roles t)
        {
            

            string rid = ControllerContext.HttpContext.Request["rid"];
            string[] qid = ControllerContext.HttpContext.Request["qid"].Split(',');
            int del = 0;
            int add = 0;
      
            using (TransactionScope tt = new TransactionScope())
            {
                string sql = "select COUNT(1) from dbo.RolePermissions where RoleID=" + rid;
                if ((int)DBHelper.SelectSinger(sql, "UpdateRole") > 0)
                {
                    string sql2 = "delete from dbo.RolePermissions where RoleID=" + rid;
                    del = DBHelper.InsertUpdateDelte(sql2, "UpdateRole");
                }
                else
                {
                    del = 1;
                }
                foreach (var item in qid)
                {
                    string sql3 = string.Format("insert into dbo.RolePermissions(RoleID,PermissionsID) values({0},{1})", rid, item);
                    add = DBHelper.InsertUpdateDelte(sql3, "UpdateRole");
                }
         
                if (del > 0 && add > 0 && role.Change(t) > 0)
                {
                    tt.Complete();
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
        }
        public ActionResult DeleteJue(int id)
        {
            if (role.Del(new Roles() { RoleID = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>alert('删除成功');window.location.href='/power/right_list'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/power/right_list'</script>");
            }
        }

    }
}

