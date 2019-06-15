using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IConfigFileThirdKindBll
    {
        List<config_file_third_kind> FindAll();
        int Add(config_file_third_kind t);
        int Del(config_file_third_kind t);
        int Change(config_file_third_kind t);

    }
}
