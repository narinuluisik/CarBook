using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Command.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;  
        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author != null)
            {
                await _repository.RemoveAsync(author );
            }
        }
    }
}
