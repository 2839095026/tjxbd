using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface ISalaryStandardDetailsBll
    {
        List<salary_standard_details> FindAll();
        int Add(salary_standard_details t);
        int Del(salary_standard_details t);
        int Change(salary_standard_details t);
        List<salary_standard_details> SelectWhere(string id);

    }
}
