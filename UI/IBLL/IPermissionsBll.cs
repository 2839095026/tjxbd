using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IPermissionsBll
    {
        List<Permissions> FindAll();
        int Add(Permissions t);
        int Del(Permissions t);
        int Change(Permissions t);
    }
}
