using CarBook.Application.Features.CQRS.Queries.AppUserQueries;
using CarBook.Application.Features.CQRS.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.IAppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository appUserRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Id = user.AppUserId;
                values.IsExist = true;
                values.UserName = user.UserName;
                values.Role = user.AppRole.RoleName;
            }
            return values;
        }
    }
}
