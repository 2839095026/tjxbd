using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class SalaryGrantDao : BaseDao<salary_grant>, ISalaryGrantDao<salary_grant>
    {
        public string FindID()
        {
            var v = GetAdt().OrderByDescending(e => e.regist_time).Take(1).ToList().FirstOrDefault();
            return v != null ? v.salary_grant_id : "";
        }
        public List<salary_grant> FenYe2<K>(int pageIndex, int pageSize, out int Count, string salary_grant_id, string primarKey, string startDate, string endDate)
        {
            var indexlist = from s in GetAdt() select s;
            indexlist = indexlist.Where(p => p.check_status == 1);
            if (!string.IsNullOrEmpty(salary_grant_id))
            {
                indexlist = indexlist.Where(p => p.salary_standard_id.Contains(salary_grant_id));
            }
            if (!string.IsNullOrEmpty(primarKey))
            {
                indexlist = indexlist.Where(p => p.checker.Contains(primarKey) || p.register.Contains(primarKey));
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
