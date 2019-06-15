using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageExamBll
    {


        List<engage_exam> FindAll();
        int Add(engage_exam t);
        int Del(engage_exam t);
        int Change(engage_exam t);

    }
}
