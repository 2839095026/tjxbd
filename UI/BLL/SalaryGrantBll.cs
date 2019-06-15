using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IocContainer;
using IBLL;
using IDAO;
namespace BLL
{

    public class SalaryGrantBll : ISalaryGrantBll
    {
        ISalaryGrantDao<salary_grant> dao = IocCreate.CreateDao<ISalaryGrantDao<salary_grant>>("SalaryGrantDao");

        public int Add(salary_grant t)
        {
            return dao.Add(t);
        }

        public int Change(salary_grant t)
        {
            return dao.Change(t);
        }

        public int Del(salary_grant t)
        {
            return dao.Del(t);
        }

        public List<salary_grant> FindAll()
        {
            return dao.FindAll();
        }
    }
}
