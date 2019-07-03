using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace IBLL
{
    public interface IConfigPublicCharBll
    {

        List<config_public_char> FindAll();
        int Add(config_public_char t);
        int Del(config_public_char t);
        int Change(config_public_char t);
        DataTable FindSelect(string fileName);


    }
}
