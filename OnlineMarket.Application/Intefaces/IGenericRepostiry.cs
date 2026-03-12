using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Intefaces
{
   public interface IGenericRepostiry<T> where T : class
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        void Remove(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
