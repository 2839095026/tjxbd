using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IUsersRolesBll
    {
        List<users_roles> FindAll();
        int Add(users_roles t);
        int Del(users_roles t);
        int Change(users_roles t);
        List<users_roles> FenYe(int pageIndex, int pageSize, out int Count);
    }
}
