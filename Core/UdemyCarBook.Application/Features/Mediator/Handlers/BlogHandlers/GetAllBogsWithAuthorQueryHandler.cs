using MediatR;
using Microsoft.IdentityModel.Tokens.Experimental;
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
    public class GetAllBogsWithAuthorQueryHandler : IRequestHandler<GetAllBogsWithAuthorQuery, List<GetAllBogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBogsWithAuthorQueryResult>> Handle(GetAllBogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = _blogRepository.GetAllBlogsWithAuthors();  
            var result = blogs.Select(blog => new GetAllBogsWithAuthorQueryResult
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                AuthorName = blog.Author.Name,
                Description=blog.Description,
                AuthorID = blog.AuthorID,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                CategoryID = blog.CategoryID
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
