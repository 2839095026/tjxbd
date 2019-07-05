using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageInterviewBll
    {

        List<engage_interview> FindAll();
        int Add(engage_interview t);
        int Del(engage_interview t);
        int Change(engage_interview t);
        List<engage_interview> FindEngageInterviewByResID(string ResID);
        List<engage_interview> FindAllEngageInterviewGroupByResId(int pageIndex, int pageSize, out int count);
    }
}
