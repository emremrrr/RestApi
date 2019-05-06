using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDataContext _context;

        public Repository(AppDataContext context) => _context = context;

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public IEnumerable<T> Get() => _context.Set<T>().ToList();


        public T GetById(long Id) => _context.Set<T>().Find(Id);

        public void Remove(long id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Remove(entity);
        }

        public void Save() => _context.SaveChanges();

        public void Update(T entity) => _context.Set<T>().Attach(entity);
    }
}
