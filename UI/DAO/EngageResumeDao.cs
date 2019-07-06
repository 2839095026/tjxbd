using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class EngageResumeDao : BaseDao<engage_resume>, IEngageResumeDao<engage_resume>
    {
        public List<engage_resume> FindAllEffectiveResume(int pageInxex, int pageSize, out int count)    
        {
           return base.FenYe<int>(pageInxex, pageSize,out count, e => e.check_status == 1&&e.interview_status==0, e => e.res_id);       
        }

        public List<engage_resume> FindAllResumeByInterviewStatus(int status, int pageInxex, int pageSize, out int count)
        {
            return base.FenYe<int>(pageInxex, pageSize, out count, e => e.check_status == 1 && e.interview_status == status, e => e.res_id);

        }

        public engage_resume FindAResume(string res_id)
        {
            return SelectWhere(e => e.res_id.ToString()==res_id).ToList().FirstOrDefault();
        }

        public List<engage_resume> seachEngageResume(int pageInxex, int pageSize, string mkid, string mid, out int count, string keyWords, string startTime, string EndTime,int status)
        {
            var data = FindAll();

            data = data.Where(e => e.check_status == status).ToList();
            if (mkid != null && mkid != "")
            {
                data = data.Where(e => e.human_major_kind_id == mkid).ToList();
            }
            if (mid != null && mid != "")
            {
                data = data.Where(e => e.human_major_id == mid).ToList();
            }
           
            if (keyWords != null && keyWords != "")
            {
                data = data.Where(e => e.human_name.Contains(keyWords)&& e.human_telephone.Contains(keyWords)&& e.human_idcard.Contains(keyWords)).ToList();
            }
            if (startTime != null && startTime != "")
            {
                DateTime st = DateTime.Parse(startTime);
                data = data.Where(e => e.regist_time >=st).ToList();
            }
            if (EndTime != null && EndTime != "")
            {
                DateTime et = DateTime.Parse(EndTime).AddDays(1);
                data = data.Where(e => e.regist_time <= et).ToList();
            }
            count = data.Count();
            return data.OrderBy(e=>e.res_id).Skip((pageInxex - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
