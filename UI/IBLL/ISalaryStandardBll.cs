using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

using System.Data;

namespace IBLL
{
    public interface ISalaryStandardBll
    {
        List<salary_standard> FindAll();
        int Add(salary_standard t);
        int Del(salary_standard t);
        int Change(salary_standard t);
        string FindID();
        List<salary_standard> FenYe(int pageIndex, int pageSize, out int Count);
        List<salary_standard> FenYe2(int pageIndex, int pageSize, out int Count,string standardId,string primarKey,string startDate,string endDate);
        salary_standard SelectWhere(int id);
        DataTable XinChou(string fileName);
        DataTable XinChouMoney(string id, string fileName);
    }
}
