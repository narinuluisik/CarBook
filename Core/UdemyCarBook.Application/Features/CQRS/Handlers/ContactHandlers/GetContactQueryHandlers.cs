using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandlers
    {
        private readonly IRepository<Contact> _contactRepository;
        public GetContactQueryHandlers(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _contactRepository.GetAllAsync();
            return values.Select(X => new GetContactQueryResult
            {
                ContactID = X.ContactID,
                Name = X.Name,
                Email = X.Email,
                Subject = X.Subject,
                Message = X.Message,
                SendDate = X.SendDate
            }).ToList();
        }
    }
}
