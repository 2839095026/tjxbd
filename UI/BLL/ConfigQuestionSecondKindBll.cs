using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using IocContainer;
namespace BLL
{
    //IBLL.IConfigQuestionSecondKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigQuestionSecondKindBll>("ConfigQuestionSecondKindBll");

    public class ConfigQuestionSecondKindBll : IConfigQuestionSecondKindBll
    {
        IConfigQuestionSecondKindDao<config_question_second_kind> dao = IocCreate.CreateDao<IConfigQuestionSecondKindDao<config_question_second_kind>>("ConfigQuestionSecondKindDao");

        public int Add(config_question_second_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_question_second_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_question_second_kind t)
        {
            return dao.Del(t);
        }

        public List<config_question_second_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
