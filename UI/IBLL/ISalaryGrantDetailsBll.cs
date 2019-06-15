using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface ISalaryGrantDetailsBll
    {
        List<salary_grant_details> FindAll();
        int Add(salary_grant_details t);
        int Del(salary_grant_details t);
        int Change(salary_grant_details t);
    }
}
