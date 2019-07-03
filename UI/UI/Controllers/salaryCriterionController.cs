using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Transactions;
namespace UI.Controllers
{
    public class salaryCriterionController : Controller
    {
        IBLL.ISalaryStandardBll bll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardBll>("SalaryStandardBll");
        IBLL.ISalaryItemBll bll2 = IocContainer.IocCreate.CreateBll<IBLL.ISalaryItemBll>("SalaryItemBll");
        IBLL.ISalaryStandardDetailsBll bll3 = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardDetailsBll>("SalaryStandardDetailsBll");
        // GET: salaryCriterion
        public ActionResult salarystandard_register()
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.number = NextNumber(bll.FindID());//把自动生成的编号传给前台显示
            return View(bll2.FindAll());
        }
        //根据页面的原有的编号自动生成新的编号
        public string NextNumber(string BaseNumber)
        {
            string NewNumber = "";//新值
            int InNumber = 1;//进位
            int PlaceValue;//位值
            char[] No = BaseNumber.ToCharArray();
            for (int i = BaseNumber.Length - 1; i >= 0; i--)
            {
                if (No[i] == '9' && InNumber == 1)
                {
                    InNumber = 1;
                    NewNumber = "0" + NewNumber;
                }
                else
                    if (InNumber == 1 && No[i] >= '0' && No[i] < '9')
                {
                    PlaceValue = Int32.Parse(No[i].ToString());
                    PlaceValue = (InNumber + PlaceValue);
                    InNumber = 0;
                    NewNumber = PlaceValue.ToString() + NewNumber;
                }
                else
                {
                    InNumber = 0;
                    NewNumber = No[i] + NewNumber;
                }
            }
            if (BaseNumber == NewNumber)
                NewNumber = "0000000001";
            return NewNumber;
        }

        public ActionResult salarystandard_check_success(salary_standard ss)
        {
            ss.check_status = 1;
            if (bll.Change(ss) > 0)
            {
                return View();
            }
            return Content("<script>alert('真抱歉~复核失败');</script>");
        }

        public ActionResult salarystandard_register_success()
        {
            return View();
        }

        // POST: salaryCriterion/Create
        [HttpPost]
        public ActionResult Create(salary_standard ss, salary_standard_details[] ssd)
        {
            int num = 0;
            int j = 0;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (salary_standard_details item in ssd)
                    {
                        if (item.salary > 0)
                        {
                            j++;
                            item.standard_id = ss.standard_id;
                            item.standard_name = ss.standard_name;
                            num += bll3.Add(item);
                        }
                    }
                    ss.check_status = 0;
                    if (bll.Add(ss) > 0 && num == j)
                    {
                        ts.Complete();
                        return RedirectToAction("salarystandard_register_success");
                    }
                    return Content("<script>alert('真抱歉~提交失败了噢');</script>");
                }
            }
            catch
            {
                return Content("no");
            }
        }

        public ActionResult salarystandard_check_list()
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<salary_standard> list = bll.FenYe(index, 1, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;
            return View(list);
        }

        public ActionResult salarystandard_query_locate()
        {
            return View();
        }

        public ActionResult salarystandard_check()
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.list = bll3.SelectWhere(Request.QueryString["standard_id"]);
            return View(bll.SelectWhere(int.Parse(Request.QueryString["ssd_id"])));
        }
        public ActionResult salarystandard_query_list()
        {
            string standardId = Request.QueryString["standardId"];
            string primarKey = Request.QueryString["primarKey"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<salary_standard> list = bll.FenYe2(index, 1, out count, standardId, primarKey, startDate, endDate);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;
            return View(list);
        }

        public ActionResult salarystandard_query()
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.list = bll3.SelectWhere(Request.QueryString["standard_id"]);
            return View(bll.SelectWhere(int.Parse(Request.QueryString["ssd_id"])));
        }

        public ActionResult salarystandard_change_locate()
        {
            return View();
        }

        public ActionResult salarystandard_change_list()
        {
            string standardId = Request.QueryString["standardId"];
            string primarKey = Request.QueryString["primarKey"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<salary_standard> list = bll.FenYe2(index, 1, out count, standardId, primarKey, startDate, endDate);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;
            return View(list);
        }

        public ActionResult salarystandard_change()
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.list = bll3.SelectWhere(Request.QueryString["standard_id"]);
            return View(bll.SelectWhere(int.Parse(Request.QueryString["ssd_id"])));
        }

        [HttpPost]
        public ActionResult salarystandard_change_success(salary_standard ss, salary_standard_details[] ssd)
        {
            int num = 0;
            int j = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                salary_standard ss2 = bll.SelectWhere(ss.ssd_id);
                foreach (salary_standard_details item in ssd)
                {              
                       j++;
                    num += bll3.Change(item);
                }
                ss2.changer = ss.changer;
                ss2.change_time = ss.change_time;
                ss2.remark = ss.remark;
                ss2.salary_sum = ss.salary_sum;
                if (bll.Change(ss2) > 0 && num == j)
                {
                    ts.Complete();
                    return View();
                }
                return Content("<script>alert('真抱歉~重新提交失败了噢');</script>");
            }
        }
    }
}
