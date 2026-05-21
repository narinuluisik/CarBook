using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAdressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAdressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(v => new GetFooterAdressQueryResult
            {
                FooterAdressID = v.FooterAddressID,
                Description = v.Description,
                Address = v.Address,
                Phone = v.Phone,
                Email = v.Email
            }).ToList();
        }
    }
}
