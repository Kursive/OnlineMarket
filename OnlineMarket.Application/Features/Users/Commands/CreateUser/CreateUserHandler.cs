using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User?>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password);
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не создан");
            }
            await _userRepository.CreateAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
