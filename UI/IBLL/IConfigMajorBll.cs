using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace IBLL
{
    public interface IConfigMajorBll
    {

        List<config_major> FindAll();
        int Add(config_major t);
        int Del(config_major t);
        int Change(config_major t);

    }
}
