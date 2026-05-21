using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Command.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;  
        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing != null)
            {
                await _repository.RemoveAsync(pricing);
            }
        }
    }
}
