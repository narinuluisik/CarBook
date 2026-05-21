using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.FooterAdressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress>_repository;

        public CreateFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email
            });
        }
    }
}
