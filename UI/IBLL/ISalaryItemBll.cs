using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface ISalaryItemBll
    {
        List<salary_item> FindAll();
        int Add(salary_item t);
        int Del(salary_item t);
        int Change(salary_item t);
    }
}
