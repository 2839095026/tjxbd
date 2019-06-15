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
    //IBLL.IEngageAnswerDetailsBll bll = IocContainer.IocCreate.CreateBll<IBLL.IEngageAnswerDetailsBll>("EngageAnswerDetailsBll");

    public class EngageAnswerDetailsBll : IEngageAnswerDetailsBll
    {
        IEngageAnswerDetailsDao<engage_answer_details> dao = IocCreate.CreateDao<IEngageAnswerDetailsDao<engage_answer_details>>("EngageAnswerDetailsDao");

        public int Add(engage_answer_details t)
        {
            return dao.Add(t);
        }

        public int Change(engage_answer_details t)
        {
            return dao.Change(t);
        }

        public int Del(engage_answer_details t)
        {
            return dao.Del(t);
        }

        public List<engage_answer_details> FindAll()
        {
            return dao.FindAll();
        }
    }
}
