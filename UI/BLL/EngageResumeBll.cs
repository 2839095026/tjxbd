using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
namespace BLL
{
    //IBLL.IEngageResumeBll bll = IocContainer.IocCreate.CreateBll<IBLL.IEngageResumeBll>("EngageResumeBll");
    public class EngageResumeBll : IEngageResumeBll
    {
        IEngageResumeDao<engage_resume> dao = IocCreate.CreateDao<IEngageResumeDao<engage_resume>>("EngageResumeDao");

        public int Add(engage_resume t)
        {
            return dao.Add(t);
        }

        public int Change(engage_resume t)
        {
            return dao.Change(t);
        }

        public List<engage_resume> FindAllResumecheck_list(int pageInxex, int pageSize, out int count)
        {
            return dao.FindAllResumeByInterviewStatus(5, pageInxex, pageSize, out count);
        }

        public int Del(engage_resume t)
        {
            return dao.Del(t);
        }

        public List<engage_resume> FindAll()
        {
            return dao.FindAll();
        }

        public List<engage_resume> FindAllEffectiveResume(int pageInxex, int pageSize, out int count)
        {
            return dao.FindAllResumeByInterviewStatus(0,pageInxex, pageSize, out count);
        }

        public List<engage_resume> FindAllResumeRegisterlist(int pageInxex, int pageSize, out int count)
        {
            return dao.FindAllResumeByInterviewStatus(3, pageInxex, pageSize, out count);

        }

        public engage_resume FindAResume(string res_id)
        {
            return dao.FindAResume(res_id);
        }

        public List<engage_resume> seachEngageResume(int pageInxex, int pageSize, string mkid, string mid, out int count, string keyWords, string startTime, string EndTime, int status)
        {
            return dao.seachEngageResume(pageInxex, pageSize, mkid, mid, out count, keyWords, startTime, EndTime,status);
        }

        public List<engage_resume> FindAllResumePasslist(int pageInxex, int pageSize, out int count)
        {
            return dao.FindAllResumeByInterviewStatus(6, pageInxex, pageSize, out count);
        }
    }
}
