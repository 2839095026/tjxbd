using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<salary_standard> FenYe2<K>(int pageIndex, int pageSize, out int Count, string standardId, string primarKey, string startDate, string endDate)
        {
            var indexlist = from s in GetAdt() select s;
            indexlist = indexlist.Where(p => p.check_status == 1);
            if (!string.IsNullOrEmpty(standardId))
            {
                indexlist = indexlist.Where(p => p.standard_id.Contains(standardId));
            }
            if (!string.IsNullOrEmpty(primarKey))
            {
                indexlist = indexlist.Where(p => p.standard_name.Contains(primarKey) || p.designer.Contains(primarKey) || p.checker.Contains(primarKey) || p.changer.Contains(primarKey));
            }
            if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                DateTime startDate2 = DateTime.Parse(startDate);
                indexlist = indexlist.Where(p => p.regist_time >= startDate2);
            }
            if (!string.IsNullOrEmpty(endDate) && string.IsNullOrEmpty(startDate))
            {
                DateTime endDate2 = DateTime.Parse(endDate);
                indexlist = indexlist.Where(p => p.regist_time <= endDate2);
            }
            if (!string.IsNullOrEmpty(endDate) && !string.IsNullOrEmpty(startDate))
            {
                DateTime endDate2 = DateTime.Parse(endDate);
                DateTime startDate2 = DateTime.Parse(startDate);
                indexlist = indexlist.Where(p => p.regist_time < endDate2 && p.regist_time > startDate2);
            }
            Count = indexlist.Count();
            return indexlist.OrderBy(p => p.regist_time).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
