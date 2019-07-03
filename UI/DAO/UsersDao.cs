using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using System.Data;

namespace DAO
{
    public class UsersDao : BaseDao<users>, IUsersDao<users>
    {
        public users Login(users u)
        {
            return SelectWhere(e => e.u_name == u.u_name && e.u_password == u.u_password).FirstOrDefault();
        }
        public DataTable FindAllliangbiao(string fileName)
        {
            string sql = "select u_id, u_name, u_true_name, u_password, dbo.Roles.RoleName from dbo.users inner join dbo.Roles on users.RoleID=Roles.RoleID";
            return DBHelper.Select(sql, "UsersDao");
        }

    }
}
