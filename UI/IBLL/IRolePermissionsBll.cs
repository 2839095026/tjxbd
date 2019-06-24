using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IRolePermissionsBll
    {
        List<RolePermissions> FindAll();
        int Add(RolePermissions t);
        int Del(RolePermissions t);
        int Change(RolePermissions t);
    }
}
