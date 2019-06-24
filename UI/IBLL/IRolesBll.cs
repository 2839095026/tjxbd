using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IRolesBll
    {
        List<Roles> FindAll();
        int Add(Roles t);
        int Del(Roles t);
        int Change(Roles t);
        List<Roles> SelectWhere(int id);
        List<Roles> FenYe(int pageIndex, int pageSize, out int Count);
    }
}
