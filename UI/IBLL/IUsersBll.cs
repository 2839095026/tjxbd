using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace IBLL
{
    public interface IUsersBll
    {

        List<users> FindAll();
        int Add(users t);
        int Del(users t);
        int Change(users t);
        users Login(users u);
        DataTable FindAllliangbiao(string fileName);
        List<users> SelectWhere(int id);
        List<users> FenYe(int pageIndex, int pageSize, out int Count);

    }
}
