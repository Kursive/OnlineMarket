using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Caching
{
    public class OrdersCache
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public OrdersCache(AppDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {

            if (_cache.TryGetValue("Orders", out List<Orders> orders))
            return orders;

                orders=await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
              
            _cache.Set("Orders",orders, options);
            return orders;
        }
    }
}
