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
    public class GetBrandNameWithMaxCarQueryHandler : IRequestHandler<GetBrandNameWithMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBrandNameWithMaxCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameWithMaxCarQuery request, CancellationToken cancellationToken)
        {
            var result =  _repository.GetBrandNameWithMaxCar();
            return new GetBrandNameByMaxCarQueryResult
            {
                BrandNameByMaxCar = result
            };

        }
    }
}
