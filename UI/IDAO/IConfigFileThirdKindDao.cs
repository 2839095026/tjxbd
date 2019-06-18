using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IConfigFileThirdKindDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 根据二级机构查询三级机构
        /// </summary>
        /// <param name="skid"></param>
        /// <returns></returns>
        List<T> GetConfigFileThirdKindBySKID(string skid);
    }
}
