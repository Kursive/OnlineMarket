using MediatR;
using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtService;

        public LoginHandler(IUserRepository userRepository, IJwtProvider jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           var user = await _userRepository.GetByEmail(request.Email , cancellationToken);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new Exception("неверный пароль");
            }
            return _jwtService.GenerateToken(user);  
        }
    }
}
