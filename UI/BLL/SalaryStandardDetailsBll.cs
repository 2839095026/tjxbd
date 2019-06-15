using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;

namespace BLL
{
    //IBLL.ISalaryStandardDetailsBll bll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardDetailsBll>("SalaryStandardDetailsBll");

    public class SalaryStandardDetailsBll : ISalaryStandardDetailsBll
    {
        ISalaryStandardDetailsDao<salary_standard_details> dao = IocCreate.CreateDao<ISalaryStandardDetailsDao<salary_standard_details>>("SalaryStandardDetailsDao");

        public int Add(salary_standard_details t)
        {
            return dao.Add(t);
        }

        public int Change(salary_standard_details t)
        {
            return dao.Change(t);
        }

        public int Del(salary_standard_details t)
        {
            return dao.Del(t);
        }

        public List<salary_standard_details> FindAll()
        {
            return dao.FindAll();
        }
    }
}
