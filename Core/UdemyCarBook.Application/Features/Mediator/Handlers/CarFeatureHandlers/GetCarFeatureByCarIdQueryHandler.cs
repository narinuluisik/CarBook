using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
         private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carFeatures =  _carFeatureRepository.GetCarFeaturesByCarId(request.Id);
            var result = carFeatures.Select(cf => new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = cf.CarFeatureID,
                FeatureID = cf.FeatureID,
                FeatureName = cf.Feature?.Name,
                Available = cf.Available
            }).ToList();
            return result;

        }
    }
}
