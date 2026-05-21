using MediatR;
using Microsoft.IdentityModel.Tokens.Experimental;
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
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAdressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
           var values= await _repository.GetByIdAsync(request.Id);
        return new GetFooterAdressByIdQueryResult()
            {
                FooterAdressID = values.FooterAddressID,
                Description = values.Description,
                Address = values.Address,
                Phone = values.Phone,
                Email = values.Email
            };
        }
    }
}
