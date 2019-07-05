using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface ISalaryGrantBll
    {
        List<salary_grant> FindAll();
        int Add(salary_grant t);
        int Del(salary_grant t);
        int Change(salary_grant t);
        string FindID();
        List<salary_grant> FenYe(int pageIndex, int pageSize, out int Count);
        List<salary_grant> FenYe2(int pageIndex, int pageSize, out int Count, string salary_grant_id, string primarKey, string startDate, string endDate);
        List<salary_grant> SelectWhere(short id);
    }
}
