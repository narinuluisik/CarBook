using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        public GetSocialMediaQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public Task<List<GetServiceQueryResult>> Handle(GetServiceQuery  request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllAsync().Result;
            return Task.FromResult(values.Select(l => new GetServiceQueryResult
            {
                 ServiceID = l.ServiceID,   
                    Title = l.Title,
                    Description = l.Description,
                    IconUrl = l.IconUrl
            }).ToList());
        }
        
    }
}
