using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IEngageMajorReleaseBll
    {
        List<engage_major_release> FindAll();
        int Add(engage_major_release t);
        int Del(engage_major_release t);
        int Change(engage_major_release t);
        List<engage_major_release> FindAllEngageMajorReleaseByPage(int pageIndex, int pageSize, out int Count);
        engage_major_release FindAEngageMajorReleaseByMreID(int id);
    }
}
