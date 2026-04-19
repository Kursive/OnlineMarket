using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;


namespace OnlineMarket.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmail(string email,CancellationToken cancellationToken)
        {
            var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email)
             ?? throw new Exception();
            return userEntity;
        }

        public Task SaveChanges(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
       
    }
}
