using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IEngageResumeDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="pageInxex">第？页面</param>
        /// <param name="pageSize">页面容量</param>
        /// <param name="mkid"></param>
        /// <param name="mid"></param>
        /// <param name="count"></param>
        /// <param name="keyWords">关键字</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <returns></returns>
        List<T> seachEngageResume(int pageInxex, int pageSize, string mkid, string mid, out int count, string keyWords, string startTime, string EndTime, int status);
        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="res_id">id</param>
        /// <returns></returns>
        T FindAResume(string res_id);
        /// <summary>
        /// 获取所有有效简历
        /// </summary>
        /// <returns></returns>
        List<T> FindAllResumeByInterviewStatus(int status,int pageInxex, int pageSize, out int count);
    }
}
