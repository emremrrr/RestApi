using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        T GetById(long Id);
        IEnumerable<T> Get();
        void Save();
        void Remove(long id);
        void Update(T entity);
    }
}
