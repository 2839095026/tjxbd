using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageResumeBll
    {

        List<engage_resume> FindAll();
        int Add(engage_resume t);
        int Del(engage_resume t);
        int Change(engage_resume t);
        List<engage_resume> seachEngageResume(int pageInxex, int pageSize, string mkid, string mid, out int count, string keyWords, string startTime, string EndTime, int status);
        engage_resume FindAResume(string res_id);

        /// <summary>
        /// 获取所有有效简历
        /// </summary>
        /// <returns></returns>
        List<engage_resume> FindAllEffectiveResume(int pageInxex, int pageSize, out int count);

        List<engage_resume> FindAllResumeRegisterlist(int pageInxex, int pageSize, out int count);
        /// <summary>
        /// 录用审批
        /// </summary>
        /// <param name="pageInxex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<engage_resume> FindAllResumecheck_list(int pageInxex, int pageSize, out int count);
        /// <summary>
        /// 获取录用查询的所有
        /// </summary>
        /// <param name="pageInxex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<engage_resume> FindAllResumePasslist(int pageInxex, int pageSize, out int count);


    }

}
