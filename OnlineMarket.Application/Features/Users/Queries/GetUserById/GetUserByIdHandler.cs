using MediatR;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception($"Ошибка получения пользователя с {request.Id}");
            return new UserDto(user.Id, user.Name, user.Email,user.Password);
        }
    }
}
