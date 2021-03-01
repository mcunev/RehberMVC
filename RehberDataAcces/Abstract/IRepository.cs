using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RehberDataAcces.Abstract
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);


        void Delete(TEntity entity);



        TEntity GetById(int ID);

        //Todo: Buraya bakilacak
        List<TEntity> GetAll();

        List<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> filter = null);
    }
}
