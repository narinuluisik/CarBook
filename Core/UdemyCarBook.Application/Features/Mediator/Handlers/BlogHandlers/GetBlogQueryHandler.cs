using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;
        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public Task<List<GetBlogQueryResult>> Handle(GetBlogQuery  request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllAsync().Result;
            return Task.FromResult(values.Select(l => new GetBlogQueryResult
            {
                BlogId = l.BlogId,
                Title = l.Title,
                AuthorID = l.AuthorID,
                CoverImageUrl = l.CoverImageUrl,
                CreatedDate = l.CreatedDate,
                CategoryID = l.CategoryID
            }).ToList());
        }
        
    }
}
