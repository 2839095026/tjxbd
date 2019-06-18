using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IConfigMajorDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 获取所有职位分类
        /// </summary>
        /// <returns></returns>
        List<T> GetAllMajorKindName();
        /// <summary>
        /// 获取职位名称
        /// </summary>
        /// <param name="mkid">职位分类id</param>
        /// <returns></returns>
        List<T> GetAllMajorName(string mkid);

    }
}
