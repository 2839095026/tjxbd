using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using IBLL;
using IocContainer;
namespace BLL
{
    //IBLL.IConfigFileSecondKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileSecondKindBll>("ConfigFileFirstKindBll");

    public class ConfigFileSecondKindBll : IConfigFileSecondKindBll
    {
        IConfigFileSecondKindDao<config_file_second_kind> dao = IocCreate.CreateDao<IConfigFileSecondKindDao<config_file_second_kind>>("ConfigFileSecondKindDao");

        public int Add(config_file_second_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_file_second_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_file_second_kind t)
        {
            return dao.Del(t);
        }

        public List<config_file_second_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
