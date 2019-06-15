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

        public int Del(engage_resume t)
        {
            return dao.Del(t);
        }

        public List<engage_resume> FindAll()
        {
            return dao.FindAll();
        }
    }
}
