using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IHumanFileBll
    {
        List<human_file> FindAll();
        int Add(human_file t);
        int Del(human_file t);
        int Change(human_file t);
    }
}
