using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface ISalaryStandardDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        string FindID();
        DataTable XinChou(string fileName);
        DataTable XinChouMoney(string id,string fileName);
    }
}
