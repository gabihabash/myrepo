using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PingYourPackage.Domain.Data.Contracts
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        int Edit(int id, T entity);
        int Delete(T entity);
        int Delete(int id);
        int Count();
    }
}
