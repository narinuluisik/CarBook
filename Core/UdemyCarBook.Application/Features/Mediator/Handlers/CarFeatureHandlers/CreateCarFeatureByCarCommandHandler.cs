using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.CarFeatureCommands;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
            {
                CarID = request.CarID,
                FeatureID = request.FeatureID,
                Available = request.Available
            });
        }
    }
}
