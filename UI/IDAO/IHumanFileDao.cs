using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IHumanFileDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 获取复核状态的记录
        /// 人力资源档案登记复核
        /// </summary>
        /// <returns></returns>
        List<T> FindCheckList(int pageInxex, int pageSize, out int count);


        T FindHumanFileByHumanId(string humanid);

        List<T> FindAllHumanFileByState(int pageInxex, int pageSize, out int count, Expression<Func<T, bool>> where);

    }
}
