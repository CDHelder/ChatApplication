using ChatApplication.Data.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public virtual void Create(T obj)
        {
            dbSet.Add(obj);
        }

        public virtual void Delete(int id)
        {
            var obj = GetById(id);
            dbSet.Remove(obj);
        }

        public virtual void Delete(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual T Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            else
                return query.FirstOrDefault();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual List<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public virtual void Update(T obj)
        {
            dbSet.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Update(List<T> objs)
        {
            foreach (var obj in objs)
            {
                Update(obj);
            }
        }

        public void Delete(List<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Create(List<T> objs)
        {
            dbSet.AddRange(objs);
        }
    }
}
