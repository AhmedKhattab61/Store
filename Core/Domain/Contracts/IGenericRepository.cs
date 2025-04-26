using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity , TKay> where TEntity : BaseEntity<TKay>
    {
        Task<int> CountAsync(ISpecifications<TEntity, TKay> spec);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKay> spec, bool trackChanges = false);
        Task<TEntity?> GetByIdAsync(TKay id);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKay> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
