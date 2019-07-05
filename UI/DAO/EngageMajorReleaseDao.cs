using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class EngageMajorReleaseDao : BaseDao<engage_major_release>, IEngageMajorReleaseDao<engage_major_release>
    {
        public engage_major_release FindAEngageMajorReleaseByMreID(int id)
        {
            return SelectWhere(e => e.mre_id == id).ToList().FirstOrDefault();
        }

        public List<engage_major_release> FindAllEngageMajorReleaseByPage(int pageIndex, int pageSize, out int Count)
        {
            return base.FenYe<int>(pageIndex, pageSize, out Count, e => e.mre_id != 0, e => e.mre_id);
        }
    }
}
