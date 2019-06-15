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
    //IBLL.IEngageInterviewBll bll = IocContainer.IocCreate.CreateBll<IBLL.IEngageInterviewBll>("EngageInterviewBll");

    public class EngageInterviewBll : IEngageInterviewBll
    {
        IEngageInterviewDao<engage_interview> dao = IocCreate.CreateDao<IEngageInterviewDao<engage_interview>>("EngageInterviewDao");

        public int Add(engage_interview t)
        {
            return dao.Add(t);
        }

        public int Change(engage_interview t)
        {
            return dao.Change(t);
        }

        public int Del(engage_interview t)
        {
            return dao.Del(t);
        }

        public List<engage_interview> FindAll()
        {
            return dao.FindAll();
        }
    }
}
