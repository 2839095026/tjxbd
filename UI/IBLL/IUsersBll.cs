using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IUsersBll
    {

        List<users> FindAll();
        int Add(users t);
        int Del(users t);
        int Change(users t);

    }
}
