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
    public class PermissionsDao : BaseDao<Permissions>, IPermissionsDao<Permissions>
    {
        public DataTable PermissionsAll(string fileName, int useId, int qxid)
        {
            string sql = string.Format(@" select * from dbo.Permissions q 
inner join(
select PermissionsID from dbo.RolePermissions  where RoleID='{0}'
)r on q.id=r.PermissionsID
 where MenuID='{1}'", useId, qxid);
            return DBHelper.Select(sql, "PermissionsDao"); 

        }
    }
}
