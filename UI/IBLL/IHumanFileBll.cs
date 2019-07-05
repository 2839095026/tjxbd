using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IHumanFileBll
    {
        List<human_file> FindAll();
        int Add(human_file t);
        int Del(human_file t);
        int Change(human_file t);
        
        human_file FindHumanFileByHumanId(string humanid);
        /// <summary>
        /// 分页获取状态为0（待审核）的记录
        /// </summary>
        /// <param name="pageInxex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<human_file> FindCheckList(int pageInxex, int pageSize, out int count);
        List<human_file> FindAllHumanFileByState(int pageInxex, int pageSize, out int count, Expression<Func<human_file, bool>> where);

    }
}
