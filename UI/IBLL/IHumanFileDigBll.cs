using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IHumanFileDigBll
    {

        List<human_file_dig> FindAll();
        int Add(human_file_dig t);
        int Del(human_file_dig t);
        int Change(human_file_dig t);
    }
}
