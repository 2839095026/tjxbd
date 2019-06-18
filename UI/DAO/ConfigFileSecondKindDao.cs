using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{

    public class ConfigFileSecondKindDao : BaseDao<config_file_second_kind>, IConfigFileSecondKindDao<config_file_second_kind>
    {

        public List<config_file_second_kind> GetConfigFileSecondKindByFKID(string fkid)
        {
            return GetAdt().Where(e => e.first_kind_id.ToString() == fkid.ToString()).ToList();
        }
    }
}
