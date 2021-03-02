using Microsoft.EntityFrameworkCore;
using RehberDataAcces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RehberDataAcces.Concrete
{
    public class EfRehberGenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()

    {
        



       
        public void Delete(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                db.Set<TEntity>()
                    .Remove(entity);
                db.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().ToList();
            }
            
        }

        public List<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext db = new TContext())
            {
                return filter == null ? db.Set<TEntity>().ToList() :
                db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int ID)
        {
            using (TContext db = new TContext())
            {
                var entity = db.Set<TEntity>().Find(ID);
                return entity;
            }
        }

        public void Insert(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteByID(int id)
        {
            using (TContext db = new TContext())
            {
                var entity = db.Set<TEntity>().Find(id);
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }
    }
}
