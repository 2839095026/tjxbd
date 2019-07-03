using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Entity;
using IDAO;
using IocContainer;

namespace BLL
{
    //IBLL.IUsersRolesBll bll = IocContainer.IocCreate.CreateBll<IUsersRolesBll>("UsersRolesBll");
    public class UsersRolesBll : IUsersRolesBll
    {
        IUsersRolesDao<users_roles> dao = IocCreate.CreateDao<IUsersRolesDao<users_roles>>("UsersRolesDao");

        public int Add(users_roles t)
        {
            return dao.Add(t);
        }

        public int Change(users_roles t)
        {
            return dao.Change(t);
        }

        public int Del(users_roles t)
        {
            return dao.Del(t);
        }

        public List<users_roles> FindAll()
        {
            return dao.FindAll();
        }
        public List<users_roles> FenYe(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<int>(pageIndex, pageSize, out Count, e => e.u_id != 0, e => e.u_id);
        }

      
    }
}
