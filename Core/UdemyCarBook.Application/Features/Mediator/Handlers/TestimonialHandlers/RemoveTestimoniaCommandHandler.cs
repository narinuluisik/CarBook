using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Command.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.Id);
            if (testimonial != null)
            {
                await _repository.RemoveAsync(testimonial);
            }
        }
    }
}
