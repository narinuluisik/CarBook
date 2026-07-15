using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarDescriptionİnterfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var carDescription = _repository.GetCarDescription(request.Id);
            if (carDescription == null)
            {
                return new GetCarDescriptionQueryResult
                {
                    CarID = request.Id,
                    Details = string.Empty
                };
            }

            return new GetCarDescriptionQueryResult
            {
                CarDescriptionID = carDescription.CarDescriptionID,
                CarID = carDescription.CarID,
                Details = carDescription.Details
            };
        }
    }
}
