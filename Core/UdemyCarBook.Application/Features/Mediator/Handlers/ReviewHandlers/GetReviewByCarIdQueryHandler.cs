using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = _reviewRepository.GetReviewByCarId(request.Id);
            return reviews.Select(r => new GetReviewByCarIdQueryResult
            {
                ReviewID = r.ReviewID,
                CustomerName = r.CustomerName,
                CustomerImage = r.CustomerImage,
                Comment = r.Comment,
                RaytingValue = r.RaytingValue,
                ReviewDate = r.ReviewDate,
                CarID = r.CarID
            }).ToList();
        }
    }
}
