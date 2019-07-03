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
    public class transferController : Controller
    {
        // GET: transfer
        IBLL.IMajorChangeBll Mb = IocContainer.IocCreate.CreateBll<IBLL.IMajorChangeBll>("MajorChangeBll");
        IBLL.ISalaryStandardBll ss = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardBll>("SalaryStandardBll");
        IBLL.IHumanFileBll HB = IocContainer.IocCreate.CreateBll<IBLL.IHumanFileBll>("HumanFileBll");
        public ActionResult register_locate()
        {
              return View();
        }
        //HumanFile表
        public ActionResult GetFirstKid()//获取一级机构
        {
            DataTable dt = HB.Selectfirst("GetFirstKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetSecondKid(string id)//根据一级id查二级机构
        {
            DataTable dt = HB.SelectSecond(id, "GetSecondKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetThirdKid(string id)//根据二级id查三级机构
        {
            DataTable dt = HB.SelectThird(id, "GetThirdKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        //MajorChange表
        public ActionResult GetFirstKidDD()//获取一级机构
        {
            DataTable dt = Mb.Selectfirst("GetFirstKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetSecondKidDD(string id)//根据一级id查二级机构
        {
            DataTable dt = Mb.SelectSecond(id, "GetSecondKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetThirdKidDD(string id)//根据二级id查三级机构
        {
            DataTable dt = Mb.SelectThird(id, "GetThirdKid");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Getkind_name()//获取新职位分类
        {
            DataTable dt = Mb.Selectkind_name("Getkind_name");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult Getmajor_name(string id)//根据新职位分类查新职位名称
        {
            DataTable dt = Mb.Selectmajor_name(id, "Getmajor_name");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetSan(string id)//根据三级机构查新职位分类
        {
            DataTable dt = Mb.SelectSan(id, "GetSan");
            return Content(JsonConvert.SerializeObject(dt));
        }


        public ActionResult register_list()//主页的分页
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List< human_file> list = HB.FenYe(index, 1, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;

            return View(list);
        }
        public ActionResult GetXinChou()//获取新薪酬
        {
            DataTable dt = ss.XinChou("GetXinChou");
            return Content(JsonConvert.SerializeObject(dt));
        }
        public ActionResult GetXinChouMoney(string id)//获取新薪酬总额
        {
            DataTable dt = ss.XinChouMoney(id, "GetXinChouMoney");
            return Content(JsonConvert.SerializeObject(dt));
        }

        [HttpGet]
        public ActionResult register(string id)
        {
            //users s = Session["user"] as users;//取值
            //ViewBag.user = s.u_true_name;
            ViewBag.st = HB.SelectWhere(Convert.ToInt32(id)).FirstOrDefault();
            
            List<human_file> list = HB.FindAll();
        
            return View(list);
        }//显示
        [HttpPost]
        public ActionResult register(major_change t)
        {

            //major_change list = Mb.SelectWhere(t.mch_id).FirstOrDefault();
            //list.change_reason = t.change_reason;
            //list.check_status = t.check_status = 1;
            t.check_status = 1;
            t.regist_time = DateTime.Now;
            if (Mb.Add(t) > 0)
            {
                return Content("<script>window.location.href='/transfer/register_success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/transfer/register'</script>");
            }
        }//调动登记的修改
     
        public ActionResult register_success()//登记成功
        {
            return View();
        }
       
        public ActionResult check_list()//调动审核的页面
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<major_change> list = Mb.FenYesh(index, 1, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;

            return View(list);
        }
        [HttpGet]
        public ActionResult check(int id)//调动审核的显示
        {
            ViewBag.st = Mb.SelectWhere(id).FirstOrDefault();
            ViewBag.id = id;
            List<major_change> list = Mb.FindAll();

            return View(list);
        }
        [HttpPost]
        public ActionResult check(major_change t, int stus, int id)
        {
            major_change list = Mb.SelectWhere(t.mch_id).FirstOrDefault();
           t.regist_time=DateTime.Now;
            t.check_time= DateTime.Now;
            if (stus > 0)
            {
                t.check_status =1;
            }
            else
            {             
                return Content("<script>alert('您的复核意见不能通过');window.location.href='/transfer/check/"+id+"'</script>");
            }

            if (Mb.Change(list) > 0)
            {
                return Content("<script>window.location.href='/transfer/check_success'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/transfer/check'</script>");
            }
        }//调动审核的修改

        public ActionResult check_success()//复核成功
        {
            return View();
        }
        public ActionResult locate()//调动查询
        {
            return View();
        }
   
        public ActionResult list(string id)
        {
           //List<major_change> list = Mb.SelectWhereType(id);
            List<human_file> list = HB.FindAll();
            return View(list);
      
        }
        public ActionResult detail(string id)
        {
           human_file hh= HB.SelectWhere(Convert.ToInt32(id)).LastOrDefault();
            ViewBag.st = hh;
            ViewBag.st2 = Mb.SelectWhere(hh.human_id).LastOrDefault();
            return View();
        }
      
      



    }
}