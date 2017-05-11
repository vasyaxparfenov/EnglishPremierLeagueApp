using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public interface IMutableRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(int id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        LocalView<TEntity> GetLocalView();

    }
}