using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IHumanFileDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);

        DataTable Selectfirst(string fileName);
        DataTable SelectSecond(string id, string fileName);
        DataTable SelectThird(string id, string fileName);

        List<T> FenYe<K>(int pageIndex, int pageSize, out int Count, Expression<Func<T, bool>> where, Expression<Func<T, K>> order);
        List<T> SelectWhere(Expression<Func<T, bool>> where);
    }
}
