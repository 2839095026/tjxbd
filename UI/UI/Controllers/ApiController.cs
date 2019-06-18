using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ApiController : Controller
    {
        /// <summary>
        /// 获取一级机构  
        /// </summary>
        /// <returns></returns>
        public ActionResult GetConfigFileFirstKind()
        {
            IBLL.IConfigFileFirstKindBll ConfigFileFirstKindBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileFirstKindBll>("ConfigFileFirstKindBll");
            List<Entity.config_file_first_kind> list = ConfigFileFirstKindBll.FindAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取二级机构
        /// 更具一级结构id查询二级机构
        /// </summary>
        /// <param name="fkid">一级机构id</param>
        /// <returns></returns>
        public ActionResult GetConfigFileSecondKindByFKID(string fkid)
        {
            if (fkid!=null&&fkid.Length!=0) {
                IBLL.IConfigFileSecondKindBll ConfigFileSecondKindBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileSecondKindBll>("ConfigFileFirstKindBll");

                List<Entity.config_file_second_kind> list = ConfigFileSecondKindBll.GetConfigFileSecondKindByFKID(fkid);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Content("{'msg':'fkid不能为空'}");
        }
        /// <summary>
        /// 获取三级机构
        /// 更具二级机构id获取三级机构
        /// </summary>
        /// <param name="skid"></param>
        /// <returns></returns>
        public ActionResult GetConfigFileThirdKindBySKID(string skid)
        {
            if (skid != null && skid.Length != 0)   
            {
                IBLL.IConfigFileThirdKindBll ConfigFileThirdKindBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileThirdKindBll>("ConfigFileFirstKindBll");

                List<Entity.config_file_third_kind> list = ConfigFileThirdKindBll.GetConfigFileThirdKindBySKID(skid);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Content("{'msg':'skid不能为空'}");
        }
        /// <summary>
        /// 获取职位分类
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllMajorKindName() {
            IBLL.IConfigMajorBll ConfigMajorBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorBll>("ConfigMajorBll");
            return Json(ConfigMajorBll.GetAllMajorKindName(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取职位名称
        /// </summary>
        /// <param name="mkid">职位分类id  major_kind_id</param>
        /// <returns></returns>
        public ActionResult GetAllMajorName(string mkid)
        {
            if (mkid != null && mkid.Length != 0)
            {
                IBLL.IConfigMajorBll ConfigMajorBll = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorBll>("ConfigMajorBll");
                List<Entity.config_major> list = ConfigMajorBll.GetAllMajorName(mkid);
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            return Content("{'msg':'mkid不能为空'}");

        }

    }
}