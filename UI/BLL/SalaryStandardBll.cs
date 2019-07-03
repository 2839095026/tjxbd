using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
using System.Data;

namespace BLL
{
    //IBLL.ISalaryStandardBll bll = IocContainer.IocCreate.CreateBll<IBLL.ISalaryStandardBll>("SalaryStandardBll");

    public class SalaryStandardBll : ISalaryStandardBll
    {
        ISalaryStandardDao<salary_standard> dao = IocCreate.CreateDao<ISalaryStandardDao<salary_standard>>("SalaryStandardDao");

        public int Add(salary_standard t)
        {
            return dao.Add(t);
        }

        public int Change(salary_standard t)
        {
            return dao.Change(t);
        }

        public int Del(salary_standard t)
        {
            return dao.Del(t);
        }

        public List<salary_standard> FindAll()
        {
            return dao.FindAll();
        }

        public string FindID()
        {
            return dao.FindID();
        }
        public DataTable XinChou(string fileName)
        {
            return dao.XinChou(fileName);
        }
        public DataTable XinChouMoney(string id, string fileName)
        {
            return dao.XinChouMoney(id,fileName);
        }
    }
}
