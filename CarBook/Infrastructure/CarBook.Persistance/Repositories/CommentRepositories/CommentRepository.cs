using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext carBookContext;

        public CommentRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public List<Comment> GetCommentByBlogId(int id)
        {
            return carBookContext.Comments.Where(x => x.BlogId == id).Include(x =>x.Blog).ToList();
        }

        public int GetCommentCountByBlogId(int id)
        {
            return carBookContext.Comments.Count(x => x.BlogId == id);
        }

        public List<Comment> GetCommentWithBlogName()
        {
            return carBookContext.Comments.Include(x => x.Blog).ToList();
        }
    }
}
