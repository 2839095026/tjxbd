using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class salaryCriterionController : Controller
    {
        // GET: salaryCriterion
        public ActionResult salarystandard_register()
        {
            return View();
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

        public void ss() { }
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
