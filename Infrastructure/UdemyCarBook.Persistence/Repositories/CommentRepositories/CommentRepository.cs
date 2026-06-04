using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
       private readonly CarBookContext _carBookContext;
        public void Create(Comment entity)
        {
          _carBookContext.Comments.Add(entity);
            _carBookContext.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _carBookContext.Comments.Select(c => new Comment
            {
                CommentID = c.CommentID,
                Name = c.Name,
                Description = c.Description,
                CreatedDate = c.CreatedDate,
                BlogID = c.BlogID,
               
            }
            ).ToList();
        }

        public Comment GetById(int id)
        {
            return _carBookContext.Comments.Find(id);
        }
        

        public void Remove(Comment entity)
        {
           var values=  _carBookContext.Comments.Find(entity.CommentID);
          _carBookContext.Comments.Remove(values);
            _carBookContext.SaveChanges();

        }

        public void Update(Comment entity)
        {
          _carBookContext.Comments.Update(entity);
            _carBookContext.SaveChanges();
        }
    }
}
