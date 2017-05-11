using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class MutableRepository<TEntity> : Repository<TEntity>, IMutableRepository<TEntity> where TEntity : class
    {
        public MutableRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Adds an element to to repository
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        /// <summary>
        /// Adds a sequence of elements to repository
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }
        /// <summary>
        /// Removes element, that corresponds to entity, from repository.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Removes a sequence of elements, that corresponds to entites, from repository. 
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public LocalView<TEntity> GetLocalView()
        {
            Context.Set<TEntity>().Load();
            return Context.Set<TEntity>().Local;
        }

        public void Remove(int id)
        {
            var toDelete = Get(id);
            Remove(toDelete);
        }

    }
}