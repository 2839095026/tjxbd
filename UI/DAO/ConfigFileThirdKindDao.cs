using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class ConfigFileThirdKindDao : BaseDao<config_file_third_kind>, IConfigFileThirdKindDao<config_file_third_kind>
    {
        public List<config_file_third_kind> GetConfigFileThirdKindBySKID(string skid)
        {
            return GetAdt().Where(e => e.second_kind_id.ToString() == skid.ToString()).ToList();

        }
    }
}
