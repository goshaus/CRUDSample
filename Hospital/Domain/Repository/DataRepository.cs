using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Domain.Repository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;


        public DataRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public void Create(TEntity item)
        {
            this._dbSet.Add(item);
            this._context.SaveChanges();
        }


        public TEntity FindById(int id)
        {
            var entity = this._dbSet.Find(id);
            return entity;
        }


        public IEnumerable<TEntity> GetAll()
        {
            var allData = this._dbSet.AsNoTracking().ToList();
            return allData;
        }


        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            var concreteData = this._dbSet.AsNoTracking().Where(predicate).ToList();
            return concreteData;
        }


        public void Remove(TEntity item)
        {
            this._dbSet.Remove(item);
            this._context.SaveChanges();
        }


        public void Update(TEntity item)
        {
            this._context.Entry(item).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
