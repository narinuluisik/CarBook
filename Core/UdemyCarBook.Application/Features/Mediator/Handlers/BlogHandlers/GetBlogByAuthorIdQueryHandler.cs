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
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = _repository.GetBlogByAuthorId(request.AuthorId);
            return blogs.Select(blog => new GetBlogByAuthorIdQueryResult
            {
                BlogId = blog.BlogId,
                AuthorID = blog.AuthorID,
                AuthorName = blog.Author.Name,
                AuthorDescription = blog.Author.Description,
                AuthorImageUrl = blog.Author.ImageUrl,
              
            }).ToList();
        }
    }
}
