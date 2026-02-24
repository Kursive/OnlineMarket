using MediatR;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUserHandler : IRequestHandler <GetAllUserQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users= await _userRepository.GetAllAsync(cancellationToken) ?? throw new Exception("Ошибка всех получения пользователей");
           return users.Select(user => new UserDto(user.Id, user.Name, user.Email, user.Password)).ToList();
        }
    }
}
