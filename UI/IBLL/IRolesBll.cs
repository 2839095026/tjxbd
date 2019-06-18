using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IRolesBll
    {
        List<Roles> FindAll();
        int Add(Roles t);
        int Del(Roles t);
        int Change(Roles t);
    }
}
