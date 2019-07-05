using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Entity;
namespace DAO
{
    public class EngageInterviewDao : BaseDao<engage_interview>, IEngageInterviewDao<engage_interview>
    {
        public List<engage_interview> FindAllEngageInterviewGroupByResId(int pageIndex, int pageSize, out int count)
        {
            List<engage_interview> data= FindAll();
            List<engage_interview>  rs=data.GroupBy(e => e.resume_id).AsEnumerable().Select(e => new engage_interview() {
                ein_id = e.FirstOrDefault().ein_id,
                human_name = e.LastOrDefault().human_name,
                human_major_kind_name = e.FirstOrDefault().human_major_kind_name,
                human_major_name = e.FirstOrDefault().human_major_name,
                interview_amount = short.Parse(e.ToList().Count.ToString()),
                registe_time=e.LastOrDefault().registe_time,
                resume_id=e.FirstOrDefault().resume_id,
                multi_quality_degree=e.LastOrDefault().multi_quality_degree
            }).ToList();
            count = rs.Count();
            return rs.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<engage_interview> FindEngageInterviewByResID(string ResID)
        {
            return SelectWhere(e => e.resume_id.ToString().Equals(ResID));
        }
    }
}
