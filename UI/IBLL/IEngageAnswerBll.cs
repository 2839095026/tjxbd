using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageAnswerBll
    {
        List<engage_answer> FindAll();
        int Add(engage_answer t);
        int Del(engage_answer t);
        int Change(engage_answer t);



    }
}
