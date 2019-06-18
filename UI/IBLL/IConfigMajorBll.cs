using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IConfigMajorBll
    {

        List<config_major> FindAll();
        int Add(config_major t);
        int Del(config_major t);
        int Change(config_major t);
        /// <summary>
        /// 获取所有职位分类
        /// </summary>
        /// <returns></returns>
        List<config_major> GetAllMajorKindName();
        /// <summary>
        /// 获取职位名称
        /// </summary>
        /// <param name="mkid">职位分类id</param>
        /// <returns></returns>
        List<config_major> GetAllMajorName(string mkid);
    }
}
