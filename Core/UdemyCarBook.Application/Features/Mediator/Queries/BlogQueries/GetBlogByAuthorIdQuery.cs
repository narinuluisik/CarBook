using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery :IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public int AuthorId { get; set; }
        public GetBlogByAuthorIdQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
