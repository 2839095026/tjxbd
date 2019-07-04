using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<salary_standard> FenYe(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<DateTime?>(pageIndex, pageSize, out Count, e => e.check_status == 0, r => r.regist_time);
        }

        public salary_standard SelectWhere(int id)
        {
            return dao.SelectWhere(e => e.ssd_id == id).FirstOrDefault();
        }

        public List<salary_standard> FenYe2(int pageIndex, int pageSize, out int Count, string standardId, string primarKey, string startDate, string endDate)
        {
            return dao.FenYe2<DateTime?>(pageIndex, pageSize, out Count, standardId, primarKey, startDate, endDate);
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
