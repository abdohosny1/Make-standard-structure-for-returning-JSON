﻿using System.Linq.Expressions;

namespace Make_standard_structure_for_returning_JSON.Core.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GellAllAsync();

        Task<IEnumerable<T>> GellAllAsync(params Expression<Func<T, object>>[] includeProperty);

        Task<T> GetByIDAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}