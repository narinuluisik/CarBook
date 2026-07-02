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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgPriceForMonthlyQueryResult>
    {
        private readonly IStatisticRepository _repository;
        public GetAvgRentPriceForMonthlyQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAvgPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMonthly();
            return new GetAvgPriceForMonthlyQueryResult
            {
                AvgPriceForMonthly = value
            };
        }
    }
}
