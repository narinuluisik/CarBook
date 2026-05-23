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
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveServiceCommands>
    {
        private readonly IRepository<Service> _repository;  
        public RemoveBlogCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommands request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.ServiceID);
            if (service != null)
            {
                await _repository.RemoveAsync(service);
            }
        }
    }
}
