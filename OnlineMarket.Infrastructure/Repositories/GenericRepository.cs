using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Application.Intefaces;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Infrastructure.EFcore;



namespace OnlineMarket.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepostiry<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken) => await _dbContext.Set<T>().ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _dbContext.Set<T>().FindAsync(id, cancellationToken);

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public async Task<T?> UpdateAsync(T enity, CancellationToken cancellation)
        {
          _dbContext.Set<T>().Update(enity);
            await _dbContext.SaveChangesAsync(cancellation);
            return enity;
        }
    }
}
