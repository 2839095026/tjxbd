using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{

    public class ResumeController : Controller
    {

        IBLL.IEngageMajorReleaseBll EngageMajorReleaseBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageMajorReleaseBll>("EngageMajorReleaseBll");
        IBLL.IEngageResumeBll EngageResumeBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");
        IBLL.IUsersBll UsersBll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");

        // GET: Resume
        public ActionResult Index()
        {

            return View();
        }
       

        public ActionResult register()
        {
            string stringId = Request.QueryString["id"];
            if (stringId != null && stringId != "")
            {
                ViewData.Model = EngageMajorReleaseBll.FindAEngageMajorReleaseByMreID(int.Parse(stringId));

            }

            IBLL.IConfigPublicCharBll PublicCharBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
            List<Entity.config_public_char> allChar= PublicCharBll.FindAll();
            //国籍
            ViewBag.nationality = allChar.Where(e => e.attribute_kind.Equals("国籍")).ToList();
            ViewBag.FamousRace = allChar.Where(e => e.attribute_kind.Equals("民族")).ToList();
            ViewBag.Religion = allChar.Where(e => e.attribute_kind.Equals("宗教信仰")).ToList();
            ViewBag.Party = allChar.Where(e => e.attribute_kind.Equals("政治面貌")).ToList();
            ViewBag.EducatedYears = allChar.Where(e => e.attribute_kind.Equals("教育年限")).ToList();
            ViewBag.EducatedMajor = allChar.Where(e => e.attribute_kind.Equals("学历")).ToList();
            ViewBag.Specility = allChar.Where(e => e.attribute_kind.Equals("特长")).ToList();
            ViewBag.Hobby = allChar.Where(e => e.attribute_kind.Equals("爱好")).ToList();
            ViewBag.hEducatedMajor = allChar.Where(e => e.attribute_kind.Equals("学历专业")).ToList();

            

            return View();
        }
        /// <summary>
        /// 简历添加
        /// </summary>
        /// <param name="engageResume"></param>
        /// <returns></returns>
        public ActionResult addEngageResume(Entity.engage_resume engageResume)
        {

            engageResume.pass_checkComment = "不通过";
            engageResume.pass_passComment = "不通过";
            engageResume.check_status = 0;
            engageResume.interview_status = 0;
            engageResume.register = (Session["user"] as Entity.users).u_name;
            engageResume.human_age =short.Parse((DateTime.Now.Year - engageResume.human_birthday.Value.Year).ToString());

            IBLL.IEngageResumeBll engageResumeBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");
            if (engageResumeBll.Add(engageResume) > 0)
            {
                return Content("<script>alert('简历登记成功');location.href='/resume/resumechoose';</script>");
            }
            return Content("<script>alert('简历登记失败');history.back();</script>");
        }

        /// <summary>
        /// 人力资源--招聘管理--简历管理--简历筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult resumechoose()
        {

            return View();
        }
        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--简历管理--简历筛选--简历筛选列表
        /// </summary>
        /// <returns></returns>
        public ActionResult resumelist()
        {
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            string keyWrods = ControllerContext.HttpContext.Request.QueryString["keyWrods"];
            string startTime = ControllerContext.HttpContext.Request.QueryString["startTime"];
            string endTime = ControllerContext.HttpContext.Request.QueryString["endTime"];
            string mkid = ControllerContext.HttpContext.Request.QueryString["mkid"];
            string mid = ControllerContext.HttpContext.Request.QueryString["mid"];
            string status = ControllerContext.HttpContext.Request.QueryString["status"];

            if (pageIndex == null || pageIndex == "")
            {
                pageIndex = "1";
            }

            int pageindexi = int.Parse(pageIndex);
            int count = 0;  
            int pageSize = 1;
            ViewData.Model = EngageResumeBll.seachEngageResume(pageindexi, pageSize, mkid, mid, out count, keyWrods, startTime, endTime,int.Parse(status));
            ViewBag.count = count;
            int pages = (count - 1) / pageSize + 1;
            ViewBag.index = pageindexi;
            ViewBag.pageSize = pageSize;
            ViewBag.countPages = pages;
            if (status.Equals("1"))
            {
                return View("validlist");
            }
            return View();
            
        }
        /// <summary>
        /// 获取简历详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult resumedetails(string id)
        {


            ViewBag.UserList = UsersBll.FindAll();
            Entity.engage_resume old= EngageResumeBll.FindAResume(id);
            if (old.pass_check_status == 0)
            {
                old.pass_check_status = 1;
            }
            if (EngageResumeBll.Change(old) > 0)
            {
                return View(EngageResumeBll.FindAResume(id));

            }
            else
            {
                return Content("<script>alert('复核失败');history.back();</script>");
            }
        }
        /// <summary>
        /// 修改简历 简历筛选编辑
        /// </summary>
        /// <param name="engageResume"></param>
        /// <returns></returns>
        public ActionResult ChangeEngageResume(Entity.engage_resume engageResume) {
           Entity.engage_resume old=  EngageResumeBll.FindAResume(engageResume.res_id.ToString());
            old.human_name = engageResume.human_name;
            old.human_email = engageResume.human_email;
            old.human_telephone = engageResume.human_telephone;
            old.human_mobilephone = engageResume.human_mobilephone;
            old.human_address = engageResume.human_address;
            old.human_postcode = engageResume.human_postcode;
            old.human_nationality = engageResume.human_nationality;
            old.human_birthplace = engageResume.human_birthplace;
            old.human_birthday = engageResume.human_birthday;
            old.human_idcard = engageResume.human_idcard;
            old.human_age=engageResume.human_age;
            old.human_college = engageResume.human_college;
            old.demand_salary_standard = engageResume.demand_salary_standard;
            old.pass_checker = engageResume.pass_checker;
            old.pass_check_time = engageResume.pass_check_time;
            old.recomandation = engageResume.recomandation;
            old.check_status = 1;
            if (EngageResumeBll.Change(old) > 0)
            {
                return Content("<script>alert('推荐成功');location.href='/resume/validresume';</script>");

            }
            else
            {
                return Content("<script>alert('推荐失败');history.back();</script>");
            }

        }


        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--简历管理--有效简历查询
        /// </summary>
        /// <returns></returns>
        public ActionResult validresume() {

            return View();
        }
        /// <summary>
        ///         您正在做的业务是：人力资源--招聘管理--简历管理--有效简历列表
        /// </summary>
        /// <returns></returns>
        public ActionResult validlist()
        {
            return View();
        }

        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--简历管理--有效简历查询--详细
        /// </summary>
        /// <returns></returns>
        public ActionResult resumeselect(string id)
        {
            
            return View(EngageResumeBll.FindAResume(id));
        }

       
        /// <summary>
        /// 获取passCheck_STATUS 的中文
        /// </summary>
        /// <param name="mcase"></param>
        /// <returns></returns>
        public static string GetCheckStatusCN(int mcase)
        {
            switch (mcase)
            {
                case 0:
                    return " 待复核";
                case 1:
                    return "通过";

                default:
                    return "";  
            }

        }
        /// <summary>
        /// 获取面试状态中文
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetInterviewStatusCN(int code)
        {
            //0 待面试 1建议面试  2建议笔试  3建议录用  4删除简历
            switch (code)
            {
                case 0:
                    return "待面试";

                case 1:
                    return "建议面试";
                case 2:
                    return "建议录用";
                case 4:
                    return "删除简历";
                default:
                    return "";
            }

        }






    }
}