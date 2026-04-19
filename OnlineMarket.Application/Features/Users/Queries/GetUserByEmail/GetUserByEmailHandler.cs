using MediatR;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {

        private readonly IUserRepository _userRepository;
        
        public GetUserByEmailHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email,cancellationToken)?? throw new Exception("Ошибка получения пользователя по почте");
            await _userRepository.SaveChangesAsync(cancellationToken);
            return new UserDto(user.Id, user.Email, user.Name, user.Password);
        }
    }
}
