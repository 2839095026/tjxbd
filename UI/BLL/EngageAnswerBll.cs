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
    //IBLL.IEngageAnswerBll bll = IocContainer.IocCreate.CreateBll<IBLL.IEngageAnswerBll>("EngageAnswerBll");

    public class EngageAnswerBll : IEngageAnswerBll
    {
        IEngageAnswerDao<engage_answer> dao = IocCreate.CreateDao<IEngageAnswerDao<engage_answer>>("EngageAnswerDao");

        public int Add(engage_answer t)
        {
            return dao.Add(t);
        }

        public int Change(engage_answer t)
        {
            return dao.Change(t);
        }

        public int Del(engage_answer t)
        {
            return dao.Del(t);
        }

        public List<engage_answer> FindAll()
        {
            return dao.FindAll();
        }
    }
}
