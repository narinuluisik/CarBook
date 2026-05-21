using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Command.ServiceCommands;
using UdemyCarBook.Application.Features.Mediator.Command.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommands>
    {
        private readonly IRepository<SocialMedia> _repository;  
        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommands request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.SocialMediaID);
            if (socialMedia  != null)
            {
                await _repository.RemoveAsync(socialMedia);
            }
        }
    }
}
