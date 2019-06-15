using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
namespace BLL
{
    public class HumanFileDigBll : IHumanFileDigBll
    {
        IHumanFileDigDao<human_file_dig> dao = IocCreate.CreateDao<IHumanFileDigDao<human_file_dig>>("HumanFileDigDao");

        public int Add(human_file_dig t)
        {
            return dao.Add(t);
        }

        public int Change(human_file_dig t)
        {
            return dao.Change(t);
        }

        public int Del(human_file_dig t)
        {
            return dao.Del(t);
        }

        public List<human_file_dig> FindAll()
        {
            return dao.FindAll();
        }
    }
}
