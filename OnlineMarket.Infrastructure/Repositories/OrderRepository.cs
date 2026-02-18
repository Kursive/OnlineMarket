using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Repositories
{
     public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext):base(dbContext)  
        {
            _dbContext = dbContext;
        }
        public Task SaveChanges(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
