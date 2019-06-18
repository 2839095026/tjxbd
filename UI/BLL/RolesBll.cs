using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using IBLL;
using IocContainer;
namespace BLL
{
    //IBLL.IRolesBll bll = IocContainer.IocCreate.CreateBll<IBLL.IRolesBll>("RolesBll");

    public class RolesBll : IRolesBll
    {
        IRolesDao<Roles> dao = IocCreate.CreateDao<IRolesDao<Roles>>("RolesDao");
        public int Add(Roles t)
        {
            return dao.Add(t);
        }

        public int Change(Roles t)
        {
            return dao.Change(t);
        }

        public int Del(Roles t)
        {
            return dao.Del(t);
        }

        public List<Roles> FindAll()
        {
            return dao.FindAll();
        }
    }
}
