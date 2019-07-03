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

        public List<salary_grant> FenYe(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<DateTime?>(pageIndex, pageSize, out Count, e => e.checker == null && e.check_status == 0, r => r.regist_time);
        }

        public List<salary_grant> FenYe2(int pageIndex, int pageSize, out int Count, string salary_grant_id, string primarKey, string startDate, string endDate)
        {
            return dao.FenYe2<DateTime?>(pageIndex, pageSize, out Count, salary_grant_id, primarKey, startDate, endDate);
        }

        public List<salary_grant> FindAll()
        {
            return dao.FindAll();
        }

        public string FindID()
        {
            return dao.FindID();
        }

        public List<salary_grant> SelectWhere(short id)
        {
            return dao.SelectWhere(e => e.sgr_id == id);
        }
    }
}
