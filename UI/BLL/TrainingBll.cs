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
    //IBLL.ITrainingBll bll = IocContainer.IocCreate.CreateBll<IBLL.ITrainingBll>("TrainingBll");

    public class TrainingBll : ITrainingBll
    {
        ITrainingDao<training> dao = IocCreate.CreateDao<ITrainingDao<training>>("TrainingDao");
        
        public int Add(training t)
        {
            return dao.Add(t);
        }

        public int Change(training t)
        {
            return dao.Change(t);
        }

        public int Del(training t)
        {
            return dao.Del(t);
        }

        public List<training> FindAll()
        {
            return dao.FindAll();
        }
    }
}
