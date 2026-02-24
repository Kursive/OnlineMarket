using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;

namespace OnlineMarket.Application.Features.Users.Commands.DeleteUser
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private IUserRepository _userRepository;

        public RemoveUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception("Ошибка удаления пользователя");
            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
