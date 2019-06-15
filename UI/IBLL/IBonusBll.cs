using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IBonusBll
    {

        List<bonus> FindAll();
        int Add(bonus t);
        int Del(bonus t);
        int Change(bonus t);

    }
}
