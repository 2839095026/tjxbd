using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Entity;
namespace DAO
{
    public class BaseDao<T> where T : class
    {
        HR_DBEntities1 adt = new HR_DBEntities1();
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns>list集合</returns>
        public List<T> FindAll()
        {
            return adt.Set<T>().Select(e => e).ToList();
        }

        /// <summary>
        /// 获取当前表的linq对象
        /// </summary>
        /// <returns></returns>
        public System.Data.Entity.DbSet<T> GetAdt()
        {
            return adt.Set<T>();
        }
        /// <summary>
        /// 获取完整的linq对象
        /// </summary>
        /// <returns></returns>
        public HR_DBEntities1 GetAllAdt() {
            return adt;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<T> SelectWhere(Expression<Func<T, bool>> where)
        {
           return adt.Set<T>().Where(where).Select(e => e).ToList();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K">分页数据类型</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面容量</param>
        /// <param name="Count">总记录数</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public List<T> FenYe<K>(int pageIndex, int pageSize, out int Count, Expression<Func<T, bool>> where, Expression<Func<T, K>> order)
        {
            var data = adt.Set<T>().Where(where);
            Count = data.Count();
            return data.OrderBy(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t)
        {
            adt.Entry<T>(t).State = System.Data.Entity.EntityState.Added;
          return adt.SaveChanges();
         
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Del(T t)
        {
            adt.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;
            return adt.SaveChanges();
        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Change(T t)
        {
            adt.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            return adt.SaveChanges();
        }



    }
}
