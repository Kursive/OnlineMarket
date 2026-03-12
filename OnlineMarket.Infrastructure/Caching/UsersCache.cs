using System;
using System.Collections.Generic;
using System.Linq;
using OnlineMarket.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OnlineMarket.Domain.Entity;


namespace OnlineMarket.Infrastructure.Cache
{
    public class UsersCache
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public UsersCache(AppDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<List<User>> GetByAllUsers()
        {
            if (_cache.TryGetValue("Users", out List<User> users))
                return users; 

            
            users = await _dbContext.Users
                .AsNoTracking() 
                .ToListAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2)); 

            _cache.Set("Users", users, options);
            return users;
        }
    }
}
