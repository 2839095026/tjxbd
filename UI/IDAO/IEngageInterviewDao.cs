using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IEngageInterviewDao<T>
    {

        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 更具简历id获取面试
        /// </summary>
        /// <param name="ResID"></param>
        /// <returns></returns>
        List<T> FindEngageInterviewByResID(string ResID);
        /// <summary>
        /// 获取每一个人的面试
        /// </summary>
        /// <returns></returns>
        List<T> FindAllEngageInterviewGroupByResId(int pageIndex,int pageSize,out int count);

    }
}
