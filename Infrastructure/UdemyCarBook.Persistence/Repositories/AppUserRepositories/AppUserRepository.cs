using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.AppRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        public readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values = await _context.AppUsers.Where(filter).ToListAsync();
            return values;
        }
    }
}
