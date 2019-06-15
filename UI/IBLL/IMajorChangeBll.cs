using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IMajorChangeBll
    {
        List<major_change> FindAll();
        int Add(major_change t);
        int Del(major_change t);
        int Change(major_change t);
    }
}
