using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected IEnumerable<TEntity> Set
            => Context.Set<TEntity>().Local.Count == 0 ? (IEnumerable<TEntity>) Context.Set<TEntity>() : Context.Set<TEntity>().Local;

        public Repository(DbContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Returns an element from repository with a certain id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id) => Context.Set<TEntity>().Find(id);

        /// <summary>
        /// Returns a List of elements from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll() => Set.ToList();

        /// <summary>
        /// Returns a List of elements from repository oredered by choosen order type and based on predicate.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="orderType"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllOrderedBy<TKey>(OrderTypeEnum orderType, Func<TEntity, TKey> predicate) => orderType == OrderTypeEnum.Ascending
            ? Set.OrderBy(predicate).ToList()
            : Set.OrderByDescending(predicate).ToList();

        /// <summary>
        /// Returns a List of elemets from repository, which corresponds to predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) => Set.Where(predicate);

        /// <summary>
        /// Returns first element, that corresponds to predicate or null, if there is no element that corresponds.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Func<TEntity, bool> predicate) => Set.SingleOrDefault(predicate);

    }
}
