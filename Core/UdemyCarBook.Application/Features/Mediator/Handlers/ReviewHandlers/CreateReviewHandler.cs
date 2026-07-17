using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CustomerName = request.CustomerName,
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                RaytingValue = request.RaytingValue,
                ReviewDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                CarID = request.CarID
            });
        }
    }
}
