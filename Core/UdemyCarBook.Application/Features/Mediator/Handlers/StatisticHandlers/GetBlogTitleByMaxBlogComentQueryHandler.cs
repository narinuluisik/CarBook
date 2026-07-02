using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticRepository;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBlogTitleByMaxBlogComentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogComentQuery, GetBlogTitleByMaxBlogComentQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBlogTitleByMaxBlogComentQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBlogTitleByMaxBlogComentQueryResult> Handle(GetBlogTitleByMaxBlogComentQuery request, CancellationToken cancellationToken)
        {
            var result =  _repository.GetBlogTitleByMaxBlogComent();
            return new GetBlogTitleByMaxBlogComentQueryResult
            {
                BlogTitleByMaxBlogComent = result
            };

        }
    }
}
