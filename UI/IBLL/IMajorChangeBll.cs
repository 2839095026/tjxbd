using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace IBLL
{
    public interface IMajorChangeBll
    {
        List<major_change> FindAll();
        int Add(major_change t);
        int Del(major_change t);
        int Change(major_change t);
        List<major_change> FenYe(int pageIndex, int pageSize, out int Count);

        List<major_change> FenYesh(int pageIndex, int pageSize, out int Count);
        DataTable Selectfirst(string fileName);
        DataTable SelectSecond(string id, string fileName);
        DataTable SelectThird(string id, string fileName);
        string FindID();
        List<major_change> SelectWhere(string id);
        DataTable Selectkind_name(string fileName);

        DataTable Selectmajor_name(string id, string fileName);
        DataTable SelectSan(string id, string fileName);

        List<major_change> SelectWhereType(string id);
        List<major_change> SelectWhere(int id);
    }
}
