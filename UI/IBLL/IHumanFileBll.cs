using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace IBLL
{
    public interface IHumanFileBll
    {
        List<human_file> FindAll();
        int Add(human_file t);
        int Del(human_file t);
        int Change(human_file t);
        DataTable Selectfirst(string fileName);
        DataTable SelectSecond(string id, string fileName);
        DataTable SelectThird(string id, string fileName);

        List<human_file> FenYe(int pageIndex, int pageSize, out int Count);
        List<human_file> SelectWhere(int id);
    }
}
