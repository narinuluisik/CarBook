using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarDescriptionİnterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int CarId)
        {
            var values = _context.CarDescriptions.FirstOrDefault(x => x.CarID == CarId);
            return values;
        }
    }
}
