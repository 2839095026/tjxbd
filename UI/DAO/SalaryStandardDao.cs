using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class SalaryStandardDao : BaseDao<salary_standard>, ISalaryStandardDao<salary_standard>
    {
        HR_DBEntities1 db = new HR_DBEntities1();
        public string FindID()
        {
            var v = db.salary_standard.OrderByDescending(e => e.regist_time).Take(1).ToList().FirstOrDefault();
            return v != null ? v.standard_id : "";
        }
    }
}
