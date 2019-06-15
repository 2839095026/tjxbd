using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IEngageMajorReleaseBll
    {
        List<engage_major_release> FindAll();
        int Add(engage_major_release t);
        int Del(engage_major_release t);
        int Change(engage_major_release t);
    }
}
