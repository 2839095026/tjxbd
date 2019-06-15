using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDAO;
using IBLL;
using DAO;
using BLL;
namespace UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ISalaryStandardBll

            IBLL.IUsersBll bll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");
            return View(bll.FindAll().FirstOrDefault());
        }
    }
}