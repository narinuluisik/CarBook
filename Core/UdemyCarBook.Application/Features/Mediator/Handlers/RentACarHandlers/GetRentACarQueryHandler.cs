using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; // CancellationToken için ekledik
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    // DEĞİŞİKLİK 1: IRequestHandler'ın ikinci parametresini List<> yaptık!
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        // DEĞİŞİKLİK 2: Task'ın içindeki dönüş tipini de List<> yaptık!
        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationID && x.Available == true);

            var result = values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarID,
                Brand= x.Car.Brand.Name,
                Model= x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,

                // Eğer Result sınıfında başka alanlar varsa (Marka, Model vs.) onları da buraya ekleyebilirsin.
            }).ToList();

            return result; // Artık result bir List<> ve Handler da List<> dönüyor. Uyuşmazlık çözüldü!
        }
    }
}