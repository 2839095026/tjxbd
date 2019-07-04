using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IConfigFileSecondKindDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 根据一级机构编号获取对应的二级机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<T> GetConfigFileSecondKindByFKID(string fkid);
        List<T> SelectWhere(Expression<Func<T, bool>> where);

    }
}
