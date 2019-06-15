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
    }
}
