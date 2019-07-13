using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class employController : Controller
    {
        

        IBLL.IEngageInterviewBll EngageInterviewBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageInterviewBll>("EngageInterviewBll");
        IBLL.IEngageResumeBll EngageResumeBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");

        // GET: employ
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--录用管理--录用申请
        /// </summary>
        /// <returns></returns>
        public ActionResult registerlist()
        {
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            if (pageIndex == null || pageIndex == "")
            {

                pageIndex = "1";
            }
            int pageS = 1;
            int count = 0;
            ViewData.Model = EngageResumeBll.FindAllResumeRegisterlist(int.Parse(pageIndex), pageS, out count);
            ViewBag.count = count;
            ViewBag.index = int.Parse(pageIndex);
            ViewBag.pages = (count - 1) / pageS + 1;
            return View();

        }

        /// <summary>
        ///  您正在做的业务是：人力资源--招聘管理--录用管理--录用申请
        /// </summary>
        /// <returns></returns>
        public ActionResult register(string id)
        {
            Entity.engage_resume rs = EngageResumeBll.FindAResume(id);  
            ViewBag.resume = rs;
            ViewBag.engageInterviewList = EngageInterviewBll.FindEngageInterviewByResID(id).OrderBy(e => e.ein_id).ToList() ;
            return View();
        }

        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--录用管理--录用审批
        /// </summary>
        /// <returns></returns>
        public ActionResult check_list()
        {
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            if (pageIndex == null || pageIndex == "")
            {

                pageIndex = "1";
            }
            int pageS = 1;
            int count = 0;
            ViewData.Model = EngageResumeBll.FindAllResumecheck_list(int.Parse(pageIndex), pageS, out count);
            ViewBag.count = count;
            ViewBag.index = int.Parse(pageIndex);
            ViewBag.pages = (count - 1) / pageS + 1;

            return View();
        }

        /// <summary>
        /// 通过录用申请
        /// </summary>
        /// <param name="engageResume"></param>
        /// <returns></returns>
        public ActionResult PassRegister(Entity.engage_resume engageResume)
        {
            Entity.engage_resume old=  EngageResumeBll.FindAResume(engageResume.res_id.ToString());
            old.pass_passComment = engageResume.pass_passComment;
            old.interview_status = engageResume.interview_status;
            if (EngageResumeBll.Change(old)>0) {
                Util.EmailHelper.SendEmail("hr管理系统", "尊敬的" + old.human_name + "先生/女士 您已被我公司录用", old.human_email);

                return Content("<script>alert('提交成功');location.href='/employ/check_list';</script>");
            }
            else
            {
                return Content("<script>alert('提交成功');history.back();</script>");

            }
            
        }



        public ActionResult checkResume(Entity.engage_resume engageResume) {
            Entity.engage_resume old= EngageResumeBll.FindAResume(engageResume.res_id.ToString());
            old.pass_passComment = engageResume.pass_passComment;
            if (EngageResumeBll.Change(old)>0) {

                return Content("<script>alert('提交成功');location.href='/employ/check_list'</script>");
            }
            else
            {

                return Content("<script>alert('提交失败');history.back();</script>");

            }
        }

        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--录用管理--录用审批
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult check(string id)
        {
            Entity.engage_resume rs = EngageResumeBll.FindAResume(id);
            ViewBag.resume = rs;
            ViewBag.engageInterviewList = EngageInterviewBll.FindEngageInterviewByResID(id).OrderBy(e => e.ein_id).ToList();
            return View();

        }
        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--录用管理--录用查询
        /// </summary>
        /// <returns></returns>
        public ActionResult list()
        {
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            if (pageIndex == null || pageIndex == "")
            {

                pageIndex = "1";
            }
            int pageS = 1;
            int count = 0;
            ViewData.Model = EngageResumeBll.FindAllResumePasslist(int.Parse(pageIndex), pageS, out count);
            ViewBag.count = count;
            ViewBag.index = int.Parse(pageIndex);
            ViewBag.pages = (count - 1) / pageS + 1;
            return View();
        }


        public ActionResult details(string id)
        {
            Entity.engage_resume rs = EngageResumeBll.FindAResume(id);
            ViewBag.resume = rs;
            ViewBag.engageInterviewList = EngageInterviewBll.FindEngageInterviewByResID(id).OrderBy(e => e.ein_id).ToList();
            return View();
   
        }

    }
}