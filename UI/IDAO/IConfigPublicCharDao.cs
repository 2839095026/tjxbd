using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IConfigPublicCharDao<T>
    {

        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        DataTable FindSelect(string fileName);

    }
}
