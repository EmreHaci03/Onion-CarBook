using CarBook.Application.Features.CQRS.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new AppUser
            {
                Name= request.Name,
                Surname= request.Surname,
                Email= request.Email,
                UserName = request.UserName,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });
        }
    }
}
