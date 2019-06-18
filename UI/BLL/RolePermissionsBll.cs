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
    //IBLL.IRolePermissionsBll bll = IocContainer.IocCreate.CreateBll<IBLL.IRolePermissionsBll>("RolePermissionsBll");

    public class RolePermissionsBll : IRolePermissionsBll
    {
        IRolePermissionsDao<RolePermissions> dao = IocCreate.CreateDao<IRolePermissionsDao<RolePermissions>>("RolePermissionsDao");
        public int Add(RolePermissions t)
        {
            return dao.Add(t);
        }

        public int Change(RolePermissions t)
        {
            return dao.Change(t);
        }

        public int Del(RolePermissions t)
        {
            return dao.Del(t);
        }

        public List<RolePermissions> FindAll()
        {
            return dao.FindAll();
        }
    }
}
