using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;
namespace IBLL
{
    public interface IConfigFileFirstKindBll
    {
        
        List<config_file_first_kind> FindAll();
        int Add(config_file_first_kind t);
        int Del(config_file_first_kind t);
        int Change(config_file_first_kind t);
        List<config_file_first_kind> SelectWhere(int id);

    }
}
