using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface ITrainingBll
    {
        List<training> FindAll();
        int Add(training t);
        int Del(training t);
        int Change(training t);

    }
}
