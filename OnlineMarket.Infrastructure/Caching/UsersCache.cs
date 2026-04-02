using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;



namespace OnlineMarket.Infrastructure.Cache
{
    public class UsersCache
    {
        private readonly AppDbContext _dbContext;
        private readonly IDistributedCache _cache;

        public UsersCache(AppDbContext dbContext, IDistributedCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<List<User>> GetByAllUsers()
        {
           
            var cachedData = await _cache.GetStringAsync("users");

            if (cachedData != null)
            {
                return JsonSerializer.Deserialize<List<User>>(cachedData);
            }

           
            var users = await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();

           
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

           
            await _cache.SetStringAsync(
                "users",
                JsonSerializer.Serialize(users),
                options);

            return users;
        }
        public async Task CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            await _cache.RemoveAsync("users");
        }
    }
}
