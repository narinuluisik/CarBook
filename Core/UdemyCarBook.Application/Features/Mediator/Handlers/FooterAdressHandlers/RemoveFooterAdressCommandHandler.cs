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
    public class RemoveFooterAdressCommandHandler : IRequestHandler<RemoveFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        public RemoveFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
             await _repository.RemoveAsync(values);
        }
    }
}
