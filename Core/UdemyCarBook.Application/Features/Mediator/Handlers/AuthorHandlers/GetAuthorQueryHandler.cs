using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery     request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllAsync().Result;
            return Task.FromResult(values.Select(l => new GetAuthorQueryResult
            {
                 Id = l.Id,   
                    Name = l.Name,
                    Description = l.Description,
                    ImageUrl = l.ImageUrl
            }).ToList());
        }
        
    }
}
