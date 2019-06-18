using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class ConfigMajorDao : BaseDao<config_major>, IConfigMajorDao<config_major>
    {
        public List<config_major> GetAllMajorKindName()
        {
            var data = GetAdt().GroupBy(e => e.major_kind_id);
            var list = data.AsEnumerable().Select(e => new config_major()
            {
                major_kind_id = e.FirstOrDefault().major_kind_id,
                major_kind_name = e.FirstOrDefault().major_kind_name

            }).ToList();
            return list;
        }

        public List<config_major> GetAllMajorName(string mkid)
        {
            return GetAdt().Where(e => e.major_kind_id.ToString() == mkid).AsEnumerable().Select(e => new config_major() { major_id = e.major_id, major_name = e.major_name }).ToList();
        }
    }
}
