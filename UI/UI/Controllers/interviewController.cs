using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Transactions;
namespace UI.Controllers
{
    public class interviewController : Controller
    {
        IBLL.IEngageInterviewBll EngageInterviewBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageInterviewBll>("EngageInterviewBll");
        IBLL.IEngageResumeBll EngageResumeBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");
        IBLL.IUsersBll UsersBll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");

        // GET: interview
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--面试管理--面试结果登记--有效简历列表 check_status 为1显示
        /// </summary>
        /// <returns></returns>
        public ActionResult interviewlist()
        {
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            if (pageIndex == null || pageIndex == "")
            {

                pageIndex = "1";
            }
            int pageS = 1;
            int count = 0;
            ViewData.Model = EngageResumeBll.FindAllEffectiveResume(int.Parse(pageIndex), pageS, out count);
            ViewBag.count = count;
            ViewBag.index = int.Parse(pageIndex);
            ViewBag.pages = (count - 1) / pageS + 1;
            return View();
        }
        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--面试管理--面试结果登记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult interviewregister(string id)
        {
            engage_resume resume = EngageResumeBll.FindAResume(id);
            ViewData.Model = resume;
            List<engage_interview> interviewList = EngageInterviewBll.FindEngageInterviewByResID(resume.res_id.ToString());
            ViewBag.interview_amount = interviewList.Count() + 1;
            //IBLL.IConfigPublicCharBll PublicCharBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
            //List<Entity.config_public_char> allChar = PublicCharBll.FindAll();
            //ViewBag.imageDegree=allChar.Where(e=>e.attribute_kind.Equals)
            return View();
        }

        /// <summary>
        /// 添加简历
        /// </summary>
        /// <param name="engageInterview"></param>
        /// <returns></returns>
        public ActionResult AddEngageInterview(Entity.engage_interview engageInterview)
        {
            if (EngageInterviewBll.Add(engageInterview) > 0)
            {
                return Content("<script>alert('面试登记成功');location.href='/interview/interviewlist'</script>");
            }
            return Content("<script>alert('面试登记失败');history.back()</script>");
        }

        /// <summary>-
        /// 您正在做的业务是：人力资源--招聘管理--面试管理--面试筛选--面试结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult siftlist()
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pagesize = 1;
            int count = 0;
            ViewData.Model = EngageInterviewBll.FindAllEngageInterviewGroupByResId(index, pagesize, out count);
            ViewBag.index = index;
            ViewBag.count = count;
            ViewBag.pagesize = pagesize;
            ViewBag.pages = (count - 1) / pagesize + 1;
            return View();
        }

        /// <summary>
        /// 您正在做的业务是：人力资源--招聘管理--面试管理--面试筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult interviewsift(string id)
        {

             ViewBag.users = UsersBll.FindAll();
            Entity.engage_resume rs= EngageResumeBll.FindAResume(id);

            ViewBag.resume =rs;

            ViewBag.engageInterviewList = EngageInterviewBll.FindEngageInterviewByResID(id);

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult changResume(Entity.engage_resume engageResume)
        {
            if (engageResume.interview_status == 4)
            {
                using(TransactionScope ts=new TransactionScope())
                {
                    int count = 1; int ok =0;
                   List<Entity.engage_interview> deliv=  EngageInterviewBll.FindEngageInterviewByResID(engageResume.res_id.ToString());
                    count += deliv.Count;
                    if (EngageResumeBll.Del(engageResume) > 0)
                    {
                        ok++;
                    }
                    foreach (var item in deliv)
                    {
                        if (EngageInterviewBll.Del(item) > 0)
                        {
                            ok++;
                        }
                    }
                    if (count == ok)
                    {
                        ts.Complete();
                        return Content("<script>alert('筛选提交成功');location.href='/interview/siftlist'</script>");
                    }
                    else
                    {
                        return Content("<script>alert('筛选提交失败');history.back()</script>");
                    }


                }



            }

            engage_resume en=EngageResumeBll.FindAResume(engageResume.res_id.ToString());
            en.register = engageResume.register;

            en.regist_time = engageResume.regist_time;
            en.checker = engageResume.checker;
            en.check_time = engageResume.check_time;
            en.pass_checkComment = engageResume.pass_checkComment;
            en.interview_status = engageResume.interview_status;
            if (EngageResumeBll.Change(en) > 0)
            {
                return Content("<script>alert('筛选提交成功');location.href='/interview/siftlist'</script>");
            }
            return Content("<script>alert('筛选提交失败');history.back()</script>");



        }




    }
}