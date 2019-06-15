using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageExamDetailsBll
    {
        List<engage_exam_details> FindAll();
        int Add(engage_exam_details t);
        int Del(engage_exam_details t);
        int Change(engage_exam_details t);


    }
}
