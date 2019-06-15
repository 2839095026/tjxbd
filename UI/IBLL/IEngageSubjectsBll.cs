using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageSubjectsBll
    {
        List<engage_subjects> FindAll();
        int Add(engage_subjects t);
        int Del(engage_subjects t);
        int Change(engage_subjects t);
    }
}
