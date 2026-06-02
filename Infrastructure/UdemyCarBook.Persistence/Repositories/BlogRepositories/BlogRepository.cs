using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetLast3Blog()
        {
            var blogs = _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
            return blogs;
        }
        public List<Blog> GetAllBlogsWithAuthors()
        {
            var blogs = _carBookContext.Blogs.Include(x => x.Author).ToList();
            return blogs;
        }
    }
}