using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;
        public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }
        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
          var carPricings =  _carPricingRepository.GetCarsPricingWithCars();
            return  carPricings.Select(cp => new GetCarPricingQueryResult
            {
                CarPricinId = cp.CarPricingID,
                Brand = cp.Car.Brand.Name,
                Model = cp.Car.Model,
                Amount = cp.Amount,
                CoverImageUrl = cp.Car.CoverImageUrl
            }).ToList();
        }
    }
}
