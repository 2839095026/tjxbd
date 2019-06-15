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
    //IBLL.IConfigQuestionFirstKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigQuestionFirstKindBll>("ConfigQuestionFirstKindBll");

    public class ConfigQuestionFirstKindBll : IConfigQuestionFirstKindBll
    {
        IConfigQuestionFirstKindDao<config_question_first_kind> dao = IocCreate.CreateDao<IConfigQuestionFirstKindDao<config_question_first_kind>>("ConfigQuestionFirstKindDao");

        public int Add(config_question_first_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_question_first_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_question_first_kind t)
        {
            return dao.Del(t);
        }

        public List<config_question_first_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
