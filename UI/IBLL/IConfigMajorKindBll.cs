using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IConfigMajorKindBll
    {
        List<config_major_kind> FindAll();
        int Add(config_major_kind t);
        int Del(config_major_kind t);
        int Change(config_major_kind t);

    }
}
