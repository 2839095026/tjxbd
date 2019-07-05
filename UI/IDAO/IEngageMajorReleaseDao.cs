using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IEngageMajorReleaseDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 获取分页显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        List<T> FindAllEngageMajorReleaseByPage(int pageIndex, int pageSize, out int Count);
        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns></returns>
        T FindAEngageMajorReleaseByMreID(int id);
        
    }
}
