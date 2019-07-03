using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using System.Data;

namespace DAO
{
    public class SalaryStandardDao : BaseDao<salary_standard>, ISalaryStandardDao<salary_standard>
    {
        public string FindID()
        {
            var v = GetAdt().OrderByDescending(e => e.regist_time).Take(1).ToList().FirstOrDefault();
            return v != null ? v.standard_id : "";
        }
       public  DataTable XinChou(string fileName)
        {
            string sql = "select standard_id,standard_name from dbo.salary_standard";
            return DBHelper.Select(sql,fileName);
        }
       public  DataTable XinChouMoney(string id, string fileName)
        {
            string sql = string.Format("select standard_id,salary_sum from salary_standard where standard_id='{0}'",id,fileName);
            return DBHelper.Select(sql, fileName);
        }
    }
}
