using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Entity;
using System.Data;

namespace DAO
{
    public class ConfigPublicCharDao:BaseDao<config_public_char>,IConfigPublicCharDao<config_public_char>
    {
       public  DataTable FindSelect(string fileName)
        {
            string sql = "select * from dbo.config_public_char where attribute_kind='职称'";
            return DBHelper.Select(sql, fileName);
        }

    }
}
