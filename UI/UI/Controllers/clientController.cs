using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class clientController : Controller
    {
        // GET: client
        IBLL.IConfigFileFirstKindBll Cb = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileFirstKindBll>("ConfigFileFirstKindBll");
        IBLL.IConfigFileThirdKindBll Itk = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileThirdKindBll>("ConfigFileFirstKindBll");
        IBLL.IConfigFileSecondKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileSecondKindBll>("ConfigFileFirstKindBll");
        IBLL.IConfigMajorBll Mb = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorBll>("ConfigMajorBll");
       
        IBLL.IConfigMajorKindBll bk = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorKindBll>("ConfigMajorKindBll");
       IBLL.IConfigPublicCharBll cc = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
        //I级机构设置
        public ActionResult first_kind()//I级机构设置显示 
        {
            
            List<config_file_first_kind> list = Cb.FindAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult first_kind_register()
        {
            var tt = Cb.FindAll().OrderByDescending(e => e.first_kind_id).Take(1).FirstOrDefault();
            string id = tt.first_kind_id;
            int id2 = 0;
            string first_kind_id = "";
            if (id == null || "".Equals(id))
            {
                first_kind_id = "1";
            }
            else
            {
                id2 = Convert.ToInt32(id) + 1;
                first_kind_id = id2.ToString();
            }
            ViewBag.first_kind_id = first_kind_id;
            return View();
        }
        [HttpPost]
        public ActionResult first_kind_register(config_file_first_kind t)//I级机构设置添加
        {
            if (Cb.Add(t) > 0)
            {
                return Content("<script>window.location.href='/client/first_kind_register_success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/first_kind_register'</script>");
            }
        }
        public ActionResult first_kind_register_success()//录入成功
        {
            return View();
        }
        [HttpGet]
        public ActionResult first_kind_change(int id)
        {
            ViewBag.st = Cb.SelectWhere(id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult first_kind_change(config_file_first_kind t)
        {
            config_file_first_kind list = Cb.SelectWhere(t.ffk_id).FirstOrDefault();
            list.first_kind_id = t.first_kind_id;
            list.first_kind_name = t.first_kind_name;
            list.first_kind_salary_id = t.first_kind_salary_id;
            list.first_kind_sale_id = t.first_kind_sale_id;
            if (Cb.Change(list) > 0)
            {
                return Content("<script>window.location.href='/client/first_kind_change_success'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/client/first_kind_change'</script>");
            }
        }
        public ActionResult first_kind_change_success()
        {
            return View();
        }//更改成功

        public ActionResult first_delete(int id)
        {
            if (Cb.Del(new config_file_first_kind() { ffk_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/first_delete_success'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/first_kind'</script>");
            }
        }
        public ActionResult first_delete_success()//删除成功
        {
            return View();
        }

        //II级机构设置

        public ActionResult second_kind()
        {
            List<config_file_second_kind> list = bll.FindAll();
            return View(list);

        }
        [HttpGet]
        public ActionResult second_kind_change(int id)
        {
            ViewBag.st = bll.SelectWhere(id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult second_kind_change(config_file_second_kind t)
        {
            config_file_second_kind list = bll.SelectWhere(t.fsk_id).FirstOrDefault();
         
            list.first_kind_name = t.first_kind_name;
            list.second_kind_id = t.second_kind_id;
            list.second_kind_name = t.second_kind_name;
            list.second_salary_id = t.second_salary_id;
            list.second_sale_id = t.second_sale_id;
            if (bll.Change(list) > 0)
            {
                return Content("<script>window.location.href='/client/second_kind_change_success'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/client/second_kind_change'</script>");
            }
        }//更改
        public ActionResult second_kind_change_success()
        {
            return View();
        }//更改成功
        [HttpGet]
        public ActionResult second_kind_register()
        {

            var tt = bll.FindAll().OrderByDescending(e => e.second_kind_id).Take(1).FirstOrDefault();
            string id = tt.second_kind_id;
            int id2 = 0;
            string second_kind_id = "";
            if (id == null || "".Equals(id))
            {
                second_kind_id = "1";
            }
            else
            {
                id2 = Convert.ToInt32(id) + 1;
                second_kind_id = id2.ToString();
            }
            ViewBag.second_kind_id = second_kind_id;
            List<config_file_second_kind> list = bll.FindAll();
            return View(list);
        }
        [HttpPost]

        public ActionResult second_kind_register(config_file_second_kind t)
        {
            if (bll.Add(t) > 0)
            {
                return Content("<script>window.location.href='/client/second_kind_register_success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/second_kind_register'</script>");
            }
        }
        public ActionResult second_kind_register_success()
        {
            return View();
        }

        public ActionResult second_delete(int id)
        {
            if (bll.Del(new config_file_second_kind() { fsk_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/second_delete_success'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/second_kind'</script>");
            }

        }
        public ActionResult second_delete_success()
        {
            return View();
        }

        //III级机构设置

        public ActionResult third_kind()
        {
            List<config_file_third_kind> list = Itk.FindAll();
            return View(list);
        }
        public ActionResult third_kind_change_success()
        {
            return View();
        }
        [HttpGet]
        public ActionResult third_kind_change(int id)
        {
            ViewBag.st = Itk.SelectWhere(id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult third_kind_change(config_file_third_kind t)
        {
            config_file_third_kind list = Itk.SelectWhere(t.ftk_id).FirstOrDefault();

            list.first_kind_name = t.first_kind_name;
            list.second_kind_name = t.second_kind_name;
            list.second_kind_id = t.second_kind_id;  
            list.third_kind_name = t.third_kind_name;
            list.third_kind_sale_id = t.third_kind_sale_id;
            t.third_kind_is_retail = t.third_kind_is_retail;
            if (Itk.Change(list) > 0)
            {
                return Content("<script>window.location.href='/client/third_kind_change_success'</script>");
            }
            else
            {
                return Content("<script>alert('修改失败');window.location.href='/client/third_kind_change'</script>");
            }
        }
        [HttpGet]
        public ActionResult third_kind_register()
        {

            var tt = Itk.FindAll().OrderByDescending(e => e.third_kind_id).Take(1).FirstOrDefault();
            string id = tt.third_kind_id;
            int id2 = 0;
            string third_kind_id = "";
            if (id == null || "".Equals(id))
            {
                third_kind_id = "1";
            }
            else
            {
                id2 = Convert.ToInt32(id) + 1;
                third_kind_id = id2.ToString();
            }
            ViewBag.third_kind_id = third_kind_id;
            List<config_file_third_kind> list = Itk.FindAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult third_kind_register(config_file_third_kind t)
        {
            if (Itk.Add(t) > 0)
            {
                return Content("<script>window.location.href='/client/third_kind_register_success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/third_kind_register'</script>");
            }

        }

        public ActionResult third_kind_register_success()
        {
            return View();
        }
        public ActionResult third_delete_success()
        {
            return View();
        }
        public ActionResult third_delete(int id)
        {
            if (Itk.Del(new config_file_third_kind() { ftk_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/third_delete_success'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/third_kind'</script>");
            }
        }

        //职称设置
        public ActionResult profession_design()
        {
            ViewBag.dt = cc.FindSelect("profession_design");
            
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (cc.Del(new config_public_char() { pbc_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/profession_design'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/profession_design'</script>");
            }

        }

       

        //职位分类设置

        public ActionResult major_kind()
        {

            List< config_major_kind> list = bk.FindAll();
            return View(list);
        }
        public ActionResult Deletemajor_kind(int id)
        {
            if (bk.Del(new config_major_kind() { mfk_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/major_kind'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/major_kind'</script>");
            }
        }
        [HttpGet]
        public ActionResult major_kind_add()
        {
            var tt = bk.FindAll().OrderByDescending(e => e.major_kind_id).Take(1).FirstOrDefault();
            string id = tt.major_kind_id;
            int id2 = 0;
            string major_kind_id = "";
            if (id == null || "".Equals(id))
            {
                major_kind_id = "1";
            }
            else
            {
                id2 = Convert.ToInt32(id) + 1;
                major_kind_id = id2.ToString();
            }
            ViewBag.major_kind_id = major_kind_id;
            return View();
        }
        [HttpPost]
        public ActionResult major_kind_add(config_major_kind t)
        {
            if (bk.Add(t) > 0)
            {
                return Content("<script>window.location.href='/client/third_kind_register_success'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/major_kind_add'</script>");
            }

        }

        //职位设置
        public ActionResult major()
        {
            List< config_major> list = Mb.FindAll();
            return View(list);
        }

        public ActionResult Deletemajor(int id)
        {
            if (Mb.Del(new config_major() { mak_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/major'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/major'</script>");
            }
        }
         [HttpGet]
        public ActionResult major_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult major_add(config_major t)
        {
            if (Mb.Add(t) > 0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/major'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/major_add'</script>");
            }
        }

        //公共属性设置
        public ActionResult public_char()
        {
            List<config_public_char> list = cc.FindAll();
            return View(list);
        }
        public ActionResult Deletepublic_char(int id)
        {
            if (cc.Del(new config_public_char() { pbc_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/public_char'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/public_char'</script>");
            }
        }
        [HttpGet]
        public ActionResult public_char_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult public_char_add(config_public_char t)
        {
            if (cc.Add(t) > 0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/public_char'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/public_char_add'</script>");
            }
        }

        //薪酬项目设置
        public ActionResult salary_item()
        {
            ViewBag.dt = cc.salary_itemSelect("salary_item");
            return View();
        }
        public ActionResult Deletesalary_item(int id)
        {
            if (cc.Del(new config_public_char() { pbc_id = short.Parse(id.ToString()) }) > 0)
            {

                return Content("<script>window.location.href='/client/salary_item'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/client/salary_item'</script>");
            }
        }
        [HttpGet]
        public ActionResult salary_item_register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult salary_item_register(config_public_char t)
        {
            if (cc.Add(t) > 0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/salary_item'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败');window.location.href='/client/salary_item_register'</script>");
            }
        }
    }
}