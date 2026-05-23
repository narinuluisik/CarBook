using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Command.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommands>
    {
        private readonly IRepository<Service> _repository;
        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Service
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            });
        }
    }
}
