using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Entity;
namespace DAO
{
    public class ConfigPrimaryKeyDao: BaseDao<config_primary_key>, IConfigPrimaryKeyDao<config_primary_key>
    {
    }
}
