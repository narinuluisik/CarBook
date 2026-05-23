using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogQueryHandler : IRequestHandler<GetLast3BlogQuery, List<GetLast3BlogQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLast3BlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogQueryResult>> Handle(GetLast3BlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = _blogRepository.GetLast3Blog();
            return blogs.Select(x => new GetLast3BlogQueryResult
            {
                AuthorID = x.AuthorID,
                BlogId = x.BlogId,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name


            }).ToList();    

        }
    }
}
