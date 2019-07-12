using Entity;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
namespace UI.Controllers
{
    public class salaryGrantController : Controller
    {
        IBLL.IConfigFileFirstKindBll first = IocContainer.IocCreate.CreateBll<IConfigFileFirstKindBll>("ConfigFileFirstKindBll");
        IBLL.IConfigFileSecondKindBll second = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileSecondKindBll>("ConfigFileFirstKindBll");
        IBLL.IConfigFileThirdKindBll third = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileThirdKindBll>("ConfigFileFirstKindBll");
        IBLL.IHumanFileBll bll = IocContainer.IocCreate.CreateBll<IBLL.IHumanFileBll>("HumanFileBll");
        IBLL.ISalaryStandardDetailsBll details = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardDetailsBll>("SalaryStandardDetailsBll");
        IBLL.ISalaryGrantBll grant = IocContainer.IocCreate.CreateBll<IBLL.ISalaryGrantBll>("SalaryGrantBll");
        IBLL.ISalaryItemBll item = IocContainer.IocCreate.CreateBll<IBLL.ISalaryItemBll>("SalaryItemBll");
        IBLL.ISalaryGrantDetailsBll details2 = IocContainer.IocCreate.CreateBll<IBLL.ISalaryGrantDetailsBll>("SalaryGrantDetailsBll");
        // GET: salaryGrant
        public ActionResult register_locate()
        {
            return View();
        }

        // GET: salaryGrant/Details/5
        public ActionResult register_list()
        {
            int submitType = int.Parse(Request.QueryString["submitType"]);
            if (submitType == 1)
            {
                ViewBag.submitType = 1;
                ViewBag.list = first.FindAll();
            }
            else if (submitType == 2)
            {
                ViewBag.submitType = 2;
                ViewBag.list = second.FindAll();
            }
            else if (submitType == 3)
            {
                ViewBag.submitType = 3;
                ViewBag.list = third.FindAll();
            }
            ViewBag.human = bll.FindAll().Where(e => e.human_file_status == false);
            return View();
        }

        public ActionResult register_success(salary_grant sg, salary_grant_details[] grantDetails)
        {
            int num = 0;
            int j = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (salary_grant_details item in grantDetails)
                {
                    item.bouns_sum = item.bouns_sum.HasValue == true ? item.bouns_sum : (decimal)0.0;
                    item.sale_sum = item.sale_sum.HasValue == true ? item.sale_sum : (decimal)0.0;
                    item.deduct_sum = item.deduct_sum.HasValue == true ? item.deduct_sum : (decimal)0.0;
                    j++;
                    num += details2.Add(item);
                }
                sg.check_status = 0;
                if (grant.Add(sg) > 0 && num == j)
                {
                    ts.Complete();
                    return View();
                }
                return Content("<script>alert('真抱歉~提交失败了噢');</script>");
            }
        }

        public ActionResult register_commit()
        {
            ViewBag.salary_grant_id = NextNumber(grant.FindID());
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.details = details.FindAll();
            ViewBag.human = bll.FindAll().Where(e=>e.human_file_status==false);
            ViewBag.item = item.FindAll().OrderBy(e => e.item_id).ToList();
            ViewBag.submitType = Request.QueryString["submitType"];
            ViewBag.id = Request.QueryString["id"];
            return View();
        }

        //薪酬详情
        public ActionResult list(string id)
        {
            return View(details.SelectWhere(id));
        }
        
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
                NewNumber = "HS00000001";
            return NewNumber;
        }

        public ActionResult check_list()
        {
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<salary_grant> list = grant.FenYe(index, 1, out count);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;
            return View(list);
        }

        public ActionResult check(int id)
        {
            salary_grant sg = grant.SelectWhere((short)id).FirstOrDefault();
            ViewBag.item = item.FindAll().OrderBy(e => e.item_id).ToList();
            ViewBag.sg = sg;
            users u = Session["user"] as users;
            ViewBag.user = u.u_name;
            ViewBag.details = details.FindAll();
            return View(details2.SelectWhere(sg.salary_grant_id));
        }

        public ActionResult check_success(salary_grant sg,salary_grant_details[] grantDetails)
        {
            int num = 0;
            int j = 0;
            salary_grant sg2 = grant.FindAll().Where(e=>e.sgr_id==sg.sgr_id).FirstOrDefault();
            using (TransactionScope ts = new TransactionScope())
            {
                foreach (salary_grant_details item in grantDetails)
                {
                    item.bouns_sum = item.bouns_sum.HasValue == true ? item.bouns_sum : (decimal)0.0;
                    item.sale_sum = item.sale_sum.HasValue == true ? item.sale_sum : (decimal)0.0;
                    item.deduct_sum = item.deduct_sum.HasValue == true ? item.deduct_sum : (decimal)0.0;
                    j++;
                    num += details2.Change(item);
                }
                sg2.check_status = 1;
                sg2.salary_paid_sum = sg.salary_paid_sum;
                sg2.checker = sg.checker;
                sg2.check_time = sg.check_time;
                if (grant.Change(sg2) > 0 && num == j)
                {
                    ts.Complete();
                    return View();
                }
                return Content("<script>alert('真抱歉~复核失败了噢');</script>");
            }
        }

        public ActionResult query_locate()
        {
            return View();
        }

        public ActionResult query_list()
        {
            string salaryGrantId = Request.QueryString["salaryGrantId"];
            string primarKey = Request.QueryString["primarKey"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            int index = Request.QueryString["pageIndex"] != null && Request.QueryString["pageIndex"] != "" ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int count = 0;
            List<salary_grant> list = grant.FenYe2(index, 1, out count, salaryGrantId, primarKey, startDate, endDate);
            ViewBag.count = count;
            ViewBag.index = index;
            ViewBag.pageSize = (count - 1) / 1 + 1;
            return View(list);
        }

        public ActionResult query(int id)
        {
            salary_grant sg = grant.SelectWhere((short)id).FirstOrDefault();
            ViewBag.item = item.FindAll().OrderBy(e => e.item_id).ToList();
            ViewBag.sg = sg;
            ViewBag.details = details.FindAll();
            return View(details2.SelectWhere(sg.salary_grant_id));
        }
    }
}
