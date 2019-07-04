using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
using System.Data;

namespace BLL
{
    //IBLL.IConfigPublicCharBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPublicCharBll>("ConfigPublicCharBll");

    public class ConfigPublicCharBll : IConfigPublicCharBll
    {
        IConfigPublicCharDao<config_public_char> dao = IocCreate.CreateDao<IConfigPublicCharDao<config_public_char>>("ConfigPublicCharDao");

        public int Add(config_public_char t)
        {
            return dao.Add(t);
        }

        public int Change(config_public_char t)
        {
            return dao.Change(t);
        }

        public int Del(config_public_char t)
        {
            return dao.Del(t);
        }

        public List<config_public_char> FindAll()
        {
            return dao.FindAll();
        }
        public DataTable FindSelect(string fileName)
        {
            return dao.FindSelect(fileName);
        }
    }
}
