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
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommands>
    {
        private readonly IRepository<SocialMedia> _repository;
        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommands   request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocialMedia
            {
               Icon = request.Icon,
                Name = request.Name,
                Url = request.Url

            });
        }
    }
}
