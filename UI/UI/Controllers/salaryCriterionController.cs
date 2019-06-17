using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
namespace UI.Controllers
{
    public class salaryCriterionController : Controller
    {
        IBLL.ISalaryStandardBll bll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardBll>("SalaryStandardBll");
        // GET: salaryCriterion
        public ActionResult salarystandard_register()
        {
            users s = Session["user"] as users;
            ViewBag.user = s.u_name;
            ViewBag.number = NextNumber(bll.FindID());//把自动生成的编号传给前台显示
            return View();
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

        public ActionResult test()
        {
            return View();
        }
        // GET: salaryCriterion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: salaryCriterion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: salaryCriterion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: salaryCriterion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: salaryCriterion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: salaryCriterion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: salaryCriterion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
