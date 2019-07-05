using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;

namespace IDAO
{
    public interface IUsersDao<T>
    {

        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        users Login(users u);
        DataTable FindAllliangbiao(string fileName);
        List<T> SelectWhere(Expression<Func<T, bool>> where);
        List<T> FenYe<K>(int pageIndex, int pageSize, out int Count, Expression<Func<T, bool>> where, Expression<Func<T, K>> order);
    }
}
