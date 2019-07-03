using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
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
        DataTable XinChou(string fileName);
        DataTable XinChouMoney(string id, string fileName);
    }
}
