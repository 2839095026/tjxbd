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
    //IBLL.ISalaryGrantDetailsBll bll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryGrantDetailsBll>("SalaryGrantDetailsBll");

    public class SalaryGrantDetailsBll : ISalaryGrantDetailsBll
    {

        ISalaryGrantDetailsDao<salary_grant_details> dao = IocCreate.CreateDao<ISalaryGrantDetailsDao<salary_grant_details>>("SalaryGrantDetailsDao");

        public int Add(salary_grant_details t)
        {
            return dao.Add(t);
        }

        public int Change(salary_grant_details t)
        {
            return dao.Change(t);
        }

        public int Del(salary_grant_details t)
        {
            return dao.Del(t);
        }

        public List<salary_grant_details> FindAll()
        {
            return dao.FindAll();
        }

        public List<salary_grant_details> SelectWhere(string id)
        {
            return dao.SelectWhere(e => e.salary_grant_id == id);
        }
    }
}
