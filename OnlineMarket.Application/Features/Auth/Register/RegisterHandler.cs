using MediatR;
using OnlineMarket.Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtService;

        public RegisterHandler(IJwtProvider jwtService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User(request.Name, request.Email, hashpassword);


            await _userRepository.CreateAsync(user,cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return _jwtService.GenerateToken(user);
        }
    }
}
