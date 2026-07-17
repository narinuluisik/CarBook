using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppRole> appRoleRepository, IRepository<AppUser> appUserRepository)
        {
            _appRoleRepository = appRoleRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName==request.Username && x.Password == request.Password);
            if (user == null) 
                {
                values.IsExit = false;
                }
            else
            {
                values.IsExit = true;
                values.UserName=user.UserName;
                values.UserRole = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                values.Id = user.AppUserId;
            }
            return values;
           
        }
    }
}
