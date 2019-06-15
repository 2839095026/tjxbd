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
    public class EngageSubjectsBll : IEngageSubjectsBll
    {
        IEngageSubjectsDao<engage_subjects> dao = IocCreate.CreateDao<IEngageSubjectsDao<engage_subjects>>("EngageSubjectsDao");

        public int Add(engage_subjects t)
        {
            return dao.Add(t);
        }

        public int Change(engage_subjects t)
        {
            return dao.Change(t);
        }

        public int Del(engage_subjects t)
        {
            return dao.Del(t);
        }

        public List<engage_subjects> FindAll()
        {
            return dao.FindAll();
        }
    }
}
