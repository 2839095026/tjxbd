using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{

    public interface IConfigQuestionFirstKindBll
    {

        List<config_question_first_kind> FindAll();
        int Add(config_question_first_kind t);
        int Del(config_question_first_kind t);
        int Change(config_question_first_kind t);

    }
}
