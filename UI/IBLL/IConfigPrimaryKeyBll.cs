using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IConfigPrimaryKeyBll
    {

        List<config_primary_key> FindAll();
        int Add(config_primary_key t);
        int Del(config_primary_key t);
        int Change(config_primary_key t);

    }
}
