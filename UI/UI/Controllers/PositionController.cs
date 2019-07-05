using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
namespace UI.Controllers
{
    public class PositionController : Controller
    {
        IBLL.IEngageMajorReleaseBll EngageMajorReleaseBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageMajorReleaseBll>("EngageMajorReleaseBll");
        IBLL.IUsersBll UsersBll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");


        /// <summary>
        /// GET: Position 人力资源--招聘管理--职位发布管理--职位发布登记
        /// </summary>
        /// <returns></returns>
        public ActionResult position_register()
        {
            return View();
        }
        /// <summary>
        /// 人力资源--招聘管理--职位发布管理--职位发布变更
        /// </summary>
        /// <returns></returns>
        public ActionResult position_change_update()
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            ViewBag.pageSize = 2;
            ViewData.Model = EngageMajorReleaseBll.FindAllEngageMajorReleaseByPage(index, ViewBag.pageSize, out count);
            ViewBag.count = count;
            ViewBag.pages = (count - 1) / ViewBag.pageSize + 1;
            ViewBag.index = index;
            return View();
        }

        /// <summary>
        /// 创建职位登记
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public ActionResult Create_Position_Register(engage_major_release add)
        {

            if (EngageMajorReleaseBll.Add(add) > 0)
            {
                return Content("ok");
            }
            return Content("no");
        }

        /// <summary>
        /// 人力资源--招聘管理--职位发布管理--职位发布变更
        /// </summary>
        /// <param name="id">职位id</param>
        /// <returns></returns>
        public ActionResult position_release_change(int id)
        {
            ViewBag.UserList = UsersBll.FindAll();
            ViewData.Model = EngageMajorReleaseBll.FindAEngageMajorReleaseByMreID(id);
            return View();
        }
        /// <summary>
        /// 修改职位发布信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult position_release_change(engage_major_release change)
        {
           engage_major_release old = EngageMajorReleaseBll.FindAEngageMajorReleaseByMreID(change.mre_id);
            old.human_amount = change.human_amount;
            old.engage_type = change.engage_type;
            old.deadline = change.deadline;
            old.change_time = change.change_time;
            old.major_describe = change.major_describe;
            old.engage_required = change.engage_required;
            old.changer = change.changer;
            if (EngageMajorReleaseBll.Change(old) > 0) {
                return Content("ok");
            }
            return Content("no");
        }
        
        public ActionResult position_change_del(int id)
        {
            if (EngageMajorReleaseBll.Del(EngageMajorReleaseBll.FindAEngageMajorReleaseByMreID(id)) > 0)
            {
                return Content("<script>alert('删除成功');location.href='/position/position_change_update'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');</script>");
            }
        }
        /// <summary>
        /// 人力资源--招聘管理--职位发布管理--职位发布查询
        /// </summary>
        /// <returns></returns>
        public ActionResult position_release_search() {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            ViewBag.pageSize = 2;
            ViewData.Model = EngageMajorReleaseBll.FindAllEngageMajorReleaseByPage(index, ViewBag.pageSize, out count);
            ViewBag.count = count;
            ViewBag.pages = (count - 1) / ViewBag.pageSize + 1;
            ViewBag.index = index;
            return View();
        }


    }
}