using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageAnswerDetailsBll
    {

        List<engage_answer_details> FindAll();
        int Add(engage_answer_details t);
        int Del(engage_answer_details t);
        int Change(engage_answer_details t);
    }
}
