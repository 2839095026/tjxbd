using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface ISalaryStandardDao<T>
    {
        List<T> FindAll();
        int Add(T t);
        int Del(T t);
        int Change(T t);
        string FindID();
        DataTable XinChou(string fileName);
        DataTable XinChouMoney(string id,string fileName);
        List<T> FenYe<K>(int pageIndex, int pageSize, out int Count, Expression<Func<T, bool>> where, Expression<Func<T, K>> order);
        List<T> FenYe2<K>(int pageIndex, int pageSize, out int Count, string standardId, string primarKey, string startDate, string endDate);
        List<T> SelectWhere(Expression<Func<T, bool>> where);
    }
}
