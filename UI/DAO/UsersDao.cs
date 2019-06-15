using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
namespace DAO
{
    public class UsersDao : BaseDao<users>, IUsersDao<users>
    {
        public users Login(users u)
        {
            return SelectWhere(e => e.u_name == u.u_name && e.u_password == u.u_password).FirstOrDefault();
        }
    }
}
