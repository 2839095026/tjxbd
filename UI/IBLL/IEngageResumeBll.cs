using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageResumeBll
    {

        List<engage_resume> FindAll();
        int Add(engage_resume t);
        int Del(engage_resume t);
        int Change(engage_resume t);
    }
}
