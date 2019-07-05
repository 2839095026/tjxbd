using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class humanResourcesController : Controller
    {
        IBLL.IEngageResumeBll EngageResumeBll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");

        IBLL.ISalaryStandardBll SalaryStandardBll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardBll>("SalaryStandardBll");


        IBLL.IHumanFileBll HumanFileBll = IocContainer.IocCreate.CreateBll<IBLL.IHumanFileBll>("HumanFileBll");
        // GET: humanResources
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult human_list()
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
        /// <summary>
        /// 您正在做的业务是：人力资源--人力资源档案管理--人力资源档案登记
        /// </summary>
        /// <returns></returns>
        public ActionResult human_register()
        {
            string rid = Request.QueryString["rid"];
            if (rid != null && rid != "")
            {
                ViewData.Model = EngageResumeBll.FindAResume(rid);
            }

            IBLL.IConfigPublicCharBll PublicCharBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
            List<Entity.config_public_char> allChar = PublicCharBll.FindAll();
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
            ViewBag.ProDesignation = allChar.Where(e => e.attribute_kind.Equals("职称")).ToList();
            //薪酬标准
            ViewBag.salary_standard = SalaryStandardBll.FindAll();
            return View();
        }
        /// <summary>
        /// 添加人力资源档案
        /// </summary>
        /// <returns></returns>
        public ActionResult humanAdd(Entity.human_file humanFile)
        {
            string lastCode = HumanFileBll.FindAll().OrderBy(e => e.huf_id).LastOrDefault().human_id;
            humanFile.human_id = GetHumanId(lastCode);
            humanFile.check_status = 0;
            humanFile.file_chang_amount = 0;
            if (HumanFileBll.Add(humanFile) > 0)
            {
                return Content("<script>alert('添加成功');</script>");
            }

            return Content("<script>alert('添加失败');</script>");
        }
        public ActionResult human_check(string hId)
        {
            ViewData.Model=HumanFileBll.FindHumanFileByHumanId(hId);
            IBLL.IConfigPublicCharBll PublicCharBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
            List<Entity.config_public_char> allChar = PublicCharBll.FindAll();
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
            ViewBag.ProDesignation = allChar.Where(e => e.attribute_kind.Equals("职称")).ToList();
            //薪酬标准
            ViewBag.salary_standard = SalaryStandardBll.FindAll();


            return View();
        }

        public ActionResult check_list()
        {
           
            string pageIndex = ControllerContext.HttpContext.Request.QueryString["pageIndex"];
            if (pageIndex == null || pageIndex == "")                       
            {

                pageIndex = "1";
            }
            int pageS = 1;
            int count = 0;
            ViewData.Model = HumanFileBll.FindCheckList(int.Parse(pageIndex), pageS, out count);
            ViewBag.count = count;
            ViewBag.index = int.Parse(pageIndex);
            ViewBag.pages = (count - 1) / pageS + 1;

            return View();
            
        }

        /// <summary>
        /// 获取档案id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetHumanId(string code)
        {
            string outCode = "";
            if (code != "" && code != null && code.Trim().Length > 0)
            {
                code = code.Replace("bt", "");
                long codeInt = int.Parse(code);
                codeInt++;
                code = codeInt.ToString();
                string append = "bt";
                for (int i = 0; i < 11 - code.Length; i++)
                {
                    append += "0";

                }
                outCode = append + code;
            }
            else
            {
                outCode = "bt00000000001";
            }
            return outCode;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        public ActionResult register_choose_picture(string hid)
        {

            return View();
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <returns></returns>
        public ActionResult register_choose_attachment() {
            return View();
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="picFile"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RegisterPicture(HttpPostedFileBase picFile, string id)
        {
            string fileName = picFile.FileName;
            int fileSuffxLength = fileName.LastIndexOf(".") + 1;
            string suffx = fileName.Substring(fileSuffxLength, fileName.Length - fileSuffxLength);
            
            List<string> SuffxLsit = new List<string>() {
                "jpg","png"
            };
            if (SuffxLsit.Contains(suffx))
            {
                string webPath = "~/images/upload/image/" + id + "." + suffx;
                string FilePath = Server.MapPath(webPath);
                picFile.SaveAs(FilePath);

                Entity.human_file changeObj = HumanFileBll.FindHumanFileByHumanId(id);
                changeObj.human_picture = id + "." + suffx;

                if (HumanFileBll.Change(changeObj) > 0)
                {
                    return Content("<script>alert('文件上传成功！');history.back()</script>");

                }
                else
                {
                    return Content("<script>alert('数据库修改错误请重试！');history.back()</script>");

                }
            }
            else
            {
                return Content("<script>alert('非法后缀,请上传JPG,PNG类型的图片');history.back();</script>");
            }
            return Content("<script>alert('请勿直接进入');history.back();</script>");

        }

        public ActionResult upLoadAccFile(HttpPostedFileBase accFile, string humanId)
        {

            string fileName = accFile.FileName;
            int fileSuffxLength = fileName.LastIndexOf(".") + 1;
            string suffx = fileName.Substring(fileSuffxLength, fileName.Length - fileSuffxLength);
            List<string> SuffxLsit = new List<string>() {
                "doc","docx","ppt","pptx","txt","pdf","jpg"
            };
            if (SuffxLsit.Contains(suffx))
            {
                System.IO.DirectoryInfo file = new System.IO.DirectoryInfo(Server.MapPath("~/images/upload/acc/" + humanId));
                if (!file.Exists)
                {
                    file.Create();
                }

                string webPath = "~/images/upload/acc/"+humanId +"/"+ fileName;
                string FilePath = Server.MapPath(webPath);
                accFile.SaveAs(FilePath);
                Entity.human_file changeObj=   HumanFileBll.FindHumanFileByHumanId(humanId);
                changeObj.attachment_name = fileName;

                if (HumanFileBll.Change(changeObj) > 0)
                {
                    return Content("<script>alert('文件上传成功！');history.back()</script>");

                }
                else
                {
                    return Content("<script>alert('数据库修改错误请重试！');history.back()</script>");

                }
            }
            else
            {
                return Content("<script>alert('非法后缀,请上传JPG,PNG类型的图片');history.back();</script>");
            }
            return Content("<script>alert('请勿直接进入');history.back();</script>");

        }

        public ActionResult ChangeHumanFile(Entity.human_file humanFile,string flage)
        {
            Entity.human_file changeObjc= HumanFileBll.FindHumanFileByHumanId(humanFile.human_id);
            changeObjc.human_pro_designation = humanFile.human_pro_designation;
            changeObjc.human_name = humanFile.human_name;
            changeObjc.human_sex = humanFile.human_sex;
            changeObjc.human_email = humanFile.human_email;
            changeObjc.human_telephone = humanFile.human_telephone;
            changeObjc.human_qq = humanFile.human_qq;
            changeObjc.human_mobilephone = humanFile.human_mobilephone;
            changeObjc.human_address = humanFile.human_address;
            changeObjc.human_postcode = humanFile.human_postcode;
            changeObjc.human_nationality = humanFile.human_nationality;
            changeObjc.human_birthplace = humanFile.human_birthplace;
            changeObjc.human_birthday = humanFile.human_birthday;
            changeObjc.human_race = humanFile.human_race;
            changeObjc.human_religion = humanFile.human_religion;
            changeObjc.human_party = humanFile.human_party;
            changeObjc.human_id_card = humanFile.human_id_card;
            changeObjc.human_society_security_id = humanFile.human_society_security_id;
            changeObjc.human_age = humanFile.human_age;
            changeObjc.human_educated_degree = humanFile.human_educated_degree;
            changeObjc.human_educated_years = humanFile.human_educated_years;
            changeObjc.human_educated_major = humanFile.human_educated_major;
            changeObjc.salary_standard_id = humanFile.salary_standard_id;
            changeObjc.human_bank = humanFile.human_bank;
            changeObjc.human_account = humanFile.human_account;
            changeObjc.checker = humanFile.checker;
            changeObjc.regist_time = humanFile.regist_time;
            changeObjc.human_speciality = humanFile.human_speciality;
            changeObjc.human_hobby = humanFile.human_hobby;
            changeObjc.human_histroy_records = humanFile.human_histroy_records;
            changeObjc.human_family_membership = humanFile.human_family_membership;
            changeObjc.remark = humanFile.remark;
            changeObjc.file_chang_amount =(short)((int)changeObjc.file_chang_amount + 1);
            changeObjc.check_status = 1;
            string msg = "审核";
            if(flage!=null&& flage != "")
            {
                msg = "变更";
                changeObjc.check_status = 0;
            }
            if (HumanFileBll.Change(changeObjc)>0)
            {
                
                return Content("<script>alert('"+msg+"成功！');location.href='/humanResources/check_list';</script>");

            }
            return Content("<script>alert('" + msg + "失败！');history.back();</script>");
        }

        
        
        
        
        /// <summary>
        /// 人力资源--人力资源档案管理--人力资源档案查询
        /// </summary>
        /// <returns></returns>
        public ActionResult query_locate()
        {


            return View();
        }

        public ActionResult delete_list()
        {
            string firstKindId = Request.QueryString["firstKindId"];
            string secondKindId = Request.QueryString["secondKindId"];
            string thirdKindId = Request.QueryString["thirdKindId"];
            string MajorKindId = Request.QueryString["MajorKindId"];
            string MajorId = Request.QueryString["MajorId"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            string pageIndex = Request.QueryString["pageIndex"];
            if (pageIndex == "" || pageIndex == null)
            {
                pageIndex = "1";
            }
            int pageIndexInt = int.Parse(pageIndex);
            int pageSize = 1;
            int count = 0;
            //if(CheckString(firstKindId)&& CheckString(secondKindId)&& CheckString(thirdKindId)&& CheckString(MajorKindId)&& CheckString(MajorId)&& CheckString(startDate)&& CheckString(endDate))
            //{
            // ViewBag.data = HumanFileBll.FindAllHumanFileByState(pageIndexInt, pageSize, out count, e => e.huf_id > 0);
            //}
            //else
            //{
                List<Entity.human_file> data = HumanFileBll.FindAll();
                data=data.Where(e => e.human_file_status.Equals(false)).ToList();
                if (!CheckString(firstKindId))
                {
                  data=  data.Where(e => e.first_kind_id.Equals(firstKindId)).ToList();
                }
                if (!CheckString(secondKindId))
                {
                    data = data.Where(e => e.second_kind_id.Equals(secondKindId)).ToList();
                }
                if (!CheckString(thirdKindId))
                {
                    data = data.Where(e => e.third_kind_id.Equals(thirdKindId)).ToList();
                }
                if (!CheckString(MajorKindId))
                {
                    data = data.Where(e => e.human_major_kind_id.Equals(MajorKindId)).ToList();
                }
                if (!CheckString(MajorId))
                {
                    data = data.Where(e => e.human_major_id.Equals(MajorId)).ToList();
                }
                if (!CheckString(startDate))
                {
                    data = data.Where(e => e.regist_time>DateTime.Parse(startDate)).ToList();
                }
                if (!CheckString(endDate))
                {
                    data = data.Where(e => e.regist_time < DateTime.Parse(endDate)).ToList();
                }

            ViewBag.count = data.Count();
            data = data.Skip((pageIndexInt - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.data = data;
            ViewBag.index = pageIndexInt;
            ViewBag.pages = (ViewBag.count - 1) / pageSize + 1;
            ViewBag.pagesize = pageSize;
            //}

            return View();
        }
           public ActionResult query_list()
        {
            string firstKindId = Request.QueryString["firstKindId"];
            string secondKindId = Request.QueryString["secondKindId"];
            string thirdKindId = Request.QueryString["thirdKindId"];
            string MajorKindId = Request.QueryString["MajorKindId"];
            string MajorId = Request.QueryString["MajorId"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            string pageIndex = Request.QueryString["pageIndex"];
            if (pageIndex == "" || pageIndex == null)
            {
                pageIndex = "1";
            }
            int pageIndexInt = int.Parse(pageIndex);
            int pageSize = 1;
            int count = 0;
            //if(CheckString(firstKindId)&& CheckString(secondKindId)&& CheckString(thirdKindId)&& CheckString(MajorKindId)&& CheckString(MajorId)&& CheckString(startDate)&& CheckString(endDate))
            //{
            // ViewBag.data = HumanFileBll.FindAllHumanFileByState(pageIndexInt, pageSize, out count, e => e.huf_id > 0);
            //}
            //else
            //{
                List<Entity.human_file> data = HumanFileBll.FindAll();
                data=data.Where(e => e.human_file_status.Equals(false)).ToList();
                if (!CheckString(firstKindId))
                {
                  data=  data.Where(e => e.first_kind_id.Equals(firstKindId)).ToList();
                }
                if (!CheckString(secondKindId))
                {
                    data = data.Where(e => e.second_kind_id.Equals(secondKindId)).ToList();
                }
                if (!CheckString(thirdKindId))
                {
                    data = data.Where(e => e.third_kind_id.Equals(thirdKindId)).ToList();
                }
                if (!CheckString(MajorKindId))
                {
                    data = data.Where(e => e.human_major_kind_id.Equals(MajorKindId)).ToList();
                }
                if (!CheckString(MajorId))
                {
                    data = data.Where(e => e.human_major_id.Equals(MajorId)).ToList();
                }
                if (!CheckString(startDate))
                {
                    data = data.Where(e => e.regist_time>=DateTime.Parse(startDate)).ToList();
                }
                if (!CheckString(endDate))
                {
                    data = data.Where(e => e.regist_time < DateTime.Parse(endDate).AddDays(1)).ToList();
                }

            ViewBag.count = data.Count();
            data = data.Skip((pageIndexInt - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.data = data;
            ViewBag.index = pageIndexInt;
            ViewBag.pages = (ViewBag.count - 1) / pageSize + 1;
            ViewBag.pagesize = pageSize;
            //}

            return View();
        }

        public ActionResult change_list_information(string hId)
        {
            ViewData.Model = HumanFileBll.FindHumanFileByHumanId(hId);
            IBLL.IConfigPublicCharBll PublicCharBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");
            List<Entity.config_public_char> allChar = PublicCharBll.FindAll();
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
            ViewBag.ProDesignation = allChar.Where(e => e.attribute_kind.Equals("职称")).ToList();
            //薪酬标准
            ViewBag.salary_standard = SalaryStandardBll.FindAll();


            return View();
        }


        public ActionResult recovery_locate()
        {
            return View();
        }



        public ActionResult change_list()
        {

            string firstKindId = Request.QueryString["firstKindId"];
            string secondKindId = Request.QueryString["secondKindId"];
            string thirdKindId = Request.QueryString["thirdKindId"];
            string MajorKindId = Request.QueryString["MajorKindId"];
            string MajorId = Request.QueryString["MajorId"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            string pageIndex = Request.QueryString["pageIndex"];
            if (pageIndex == "" || pageIndex == null)
            {
                pageIndex = "1";
            }
            int pageIndexInt = int.Parse(pageIndex);
            int pageSize = 1;
            int count = 0;
            //if(CheckString(firstKindId)&& CheckString(secondKindId)&& CheckString(thirdKindId)&& CheckString(MajorKindId)&& CheckString(MajorId)&& CheckString(startDate)&& CheckString(endDate))
            //{
            // ViewBag.data = HumanFileBll.FindAllHumanFileByState(pageIndexInt, pageSize, out count, e => e.huf_id > 0);
            //}
            //else
            //{
            List<Entity.human_file> data = HumanFileBll.FindAll();
            data = data.Where(e => e.human_file_status.Equals(false)).ToList();
            if (!CheckString(firstKindId))
            {
                data = data.Where(e => e.first_kind_id.Equals(firstKindId)).ToList();
            }
            if (!CheckString(secondKindId))
            {
                data = data.Where(e => e.second_kind_id.Equals(secondKindId)).ToList();
            }
            if (!CheckString(thirdKindId))
            {
                data = data.Where(e => e.third_kind_id.Equals(thirdKindId)).ToList();
            }
            if (!CheckString(MajorKindId))
            {
                data = data.Where(e => e.human_major_kind_id.Equals(MajorKindId)).ToList();
            }
            if (!CheckString(MajorId))
            {
                data = data.Where(e => e.human_major_id.Equals(MajorId)).ToList();
            }
            if (!CheckString(startDate))
            {
                data = data.Where(e => e.regist_time >= DateTime.Parse(startDate)).ToList();
            }
            if (!CheckString(endDate))
            {
                data = data.Where(e => e.regist_time < DateTime.Parse(endDate).AddDays(1)).ToList();
            }

            ViewBag.count = data.Count();
            data = data.Skip((pageIndexInt - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.data = data;
            ViewBag.index = pageIndexInt;
            ViewBag.pages = (ViewBag.count - 1) / pageSize + 1;
            ViewBag.pagesize = pageSize;
            //}

            return View();
        }

        public ActionResult recovery_list_information(string id)
        {

            ViewData.Model = HumanFileBll.FindHumanFileByHumanId(id);
            return View();
        }

        public ActionResult recovery_list()
        {

            string firstKindId = Request.QueryString["firstKindId"];
            string secondKindId = Request.QueryString["secondKindId"];
            string thirdKindId = Request.QueryString["thirdKindId"];
            string MajorKindId = Request.QueryString["MajorKindId"];
            string MajorId = Request.QueryString["MajorId"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            string pageIndex = Request.QueryString["pageIndex"];
            if (pageIndex == "" || pageIndex == null)
            {
                pageIndex = "1";
            }
            int pageIndexInt = int.Parse(pageIndex);
            int pageSize = 1;
            int count = 0;
            //if(CheckString(firstKindId)&& CheckString(secondKindId)&& CheckString(thirdKindId)&& CheckString(MajorKindId)&& CheckString(MajorId)&& CheckString(startDate)&& CheckString(endDate))
            //{
            // ViewBag.data = HumanFileBll.FindAllHumanFileByState(pageIndexInt, pageSize, out count, e => e.huf_id > 0);
            //}
            //else
            //{
            List<Entity.human_file> data = HumanFileBll.FindAll();
            data = data.Where(e => e.human_file_status.Equals(true)).ToList();
            if (!CheckString(firstKindId))
            {
                data = data.Where(e => e.first_kind_id.Equals(firstKindId)).ToList();
            }
            if (!CheckString(secondKindId))
            {
                data = data.Where(e => e.second_kind_id.Equals(secondKindId)).ToList();
            }
            if (!CheckString(thirdKindId))
            {
                data = data.Where(e => e.third_kind_id.Equals(thirdKindId)).ToList();
            }
            if (!CheckString(MajorKindId))
            {
                data = data.Where(e => e.human_major_kind_id.Equals(MajorKindId)).ToList();
            }
            if (!CheckString(MajorId))
            {
                data = data.Where(e => e.human_major_id.Equals(MajorId)).ToList();
            }
            if (!CheckString(startDate))
            {
                data = data.Where(e => e.regist_time >= DateTime.Parse(startDate)).ToList();
            }
            if (!CheckString(endDate))
            {
                data = data.Where(e => e.regist_time < DateTime.Parse(endDate).AddDays(1)).ToList();
            }

            ViewBag.count = data.Count();
            data = data.Skip((pageIndexInt - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.data = data;
            ViewBag.index = pageIndexInt;
            ViewBag.pages = (ViewBag.count - 1) / pageSize + 1;
            ViewBag.pagesize = pageSize;
            //}

            return View();
        }


        public ActionResult query_list_information(string id)
        {

            ViewData.Model = HumanFileBll.FindHumanFileByHumanId(id);
            return View();
        }
        public ActionResult delete_list_information(string id)
        {

            ViewData.Model = HumanFileBll.FindHumanFileByHumanId(id);
            return View();
        }
        
        public ActionResult delHumanFile(string humanid)
        {
           Entity.human_file changeObj= HumanFileBll.FindHumanFileByHumanId(humanid);
           changeObj.human_file_status = true;
            if (HumanFileBll.Change(changeObj) > 0)
            {
                return Content("<script>alert('删除成功!')</script>");
            }
            else
            {

                return Content("<script>alert('删除失败!')</script>");
            }

        }

        public ActionResult delete_forever_list()
        {


            string firstKindId = Request.QueryString["firstKindId"];
            string secondKindId = Request.QueryString["secondKindId"];
            string thirdKindId = Request.QueryString["thirdKindId"];
            string MajorKindId = Request.QueryString["MajorKindId"];
            string MajorId = Request.QueryString["MajorId"];
            string startDate = Request.QueryString["startDate"];
            string endDate = Request.QueryString["endDate"];
            string pageIndex = Request.QueryString["pageIndex"];
            if (pageIndex == "" || pageIndex == null)
            {
                pageIndex = "1";
            }
            int pageIndexInt = int.Parse(pageIndex);
            int pageSize = 1;
            int count = 0;
     
            List<Entity.human_file> data = HumanFileBll.FindAll();
            data = data.Where(e => e.human_file_status.Equals(true)).ToList();
            ViewBag.count = data.Count();
            data = data.Skip((pageIndexInt - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.data = data;
            ViewBag.index = pageIndexInt;
            ViewBag.pages = (ViewBag.count - 1) / pageSize + 1;
            ViewBag.pagesize = pageSize;
            return View();

        }


        public ActionResult PhdelHumanFile(string id)
        {
            if(HumanFileBll.Del(HumanFileBll.FindHumanFileByHumanId(id)) > 0)
            {
                return Content("<script>alert('删除成功!');history.back()</script>");

            }
            else
            {
                return Content("<script>alert('删除成功!');history.back()</script>");

            }


        }


        public ActionResult recHumanFile(string humanid)
        {
            Entity.human_file changeObj = HumanFileBll.FindHumanFileByHumanId(humanid);
            changeObj.human_file_status = false;
            if (HumanFileBll.Change(changeObj) > 0)
            {
                return Content("<script>alert('恢复成功!');</script>");
            }
            else
            {

                return Content("<script>alert('恢复失败!');history.back()</script>");
            }

        }


        public ActionResult change_locate()
        {
            return View();
        }

        public ActionResult delete_locate()
        {
            return View();
        }


        public bool CheckString(string str)
        {
            if (str == "" || str == null)
            {
                return true;
            }
            return  false;

        }

    }
    }