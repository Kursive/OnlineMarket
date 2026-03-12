using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;


namespace OnlineMarket.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandlercs : IRequestHandler<UpdateUserCommand, User>
    {

        private readonly IUserRepository _userRepository;
        public UpdateUserHandlercs(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new Exception("Ошибка пользователя");
            }
            user = new User(request.Name, request.Email, request.Password);
            await _userRepository.UpdateAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
