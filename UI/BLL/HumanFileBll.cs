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
    public class HumanFileBll : IHumanFileBll
    {
        IHumanFileDao<human_file> dao = IocCreate.CreateDao<IHumanFileDao<human_file>>("HumanFileDao");

        public int Add(human_file t)
        {
            return dao.Add(t);
        }

        public int Change(human_file t)
        {
            return dao.Change(t);
        }

        public int Del(human_file t)
        {
            return dao.Del(t);
        }

        public List<human_file> FindAll()
        {
            return dao.FindAll();
        }
    }
}
