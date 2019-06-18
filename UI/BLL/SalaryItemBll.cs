using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IocContainer;
using IDAO;

namespace BLL
{
    //IBLL.IBonusBll bll = IocContainer.IocCreate.CreateBll<IBLL.IBonusBll>("BonusBll");
    public class SalaryItemBll : ISalaryItemBll
    {
        ISalaryItemDao<salary_item> dao = IocCreate.CreateDao<ISalaryItemDao<salary_item>>("SalaryItemDao");
        public int Add(salary_item t)
        {
            return dao.Add(t);
        }

        public int Change(salary_item t)
        {
            return dao.Change(t);
        }

        public int Del(salary_item t)
        {
            return dao.Del(t);
        }

        public List<salary_item> FindAll()
        {
            return dao.FindAll();
        }
    }
}
