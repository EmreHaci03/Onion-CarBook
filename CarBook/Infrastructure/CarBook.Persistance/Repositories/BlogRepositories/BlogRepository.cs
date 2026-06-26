using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetBlogCountByCategoryQuery()
        {
            return _carBookContext.Blogs.Include(x => x.BlogCategory).ToList();
        }

        public List<Blog> GetLast3BlogsWithAuthor()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).OrderByDescending(x => x.Id).Take(3).ToList();
            return values;
        }



        public List<Blog> GetBlogsWithDetails()
        {
            return _carBookContext.Blogs.Include(x => x.Author).Include(y => y.BlogCategory).ToList();
        }

        public Blog GetBlogsWithDetailsByBlogId(int id)
        {
            return _carBookContext.Blogs
               .Include(x => x.Author)
               .Include(x => x.BlogCategory)
               .Include(x=>x.Comments)
               .Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public  List<Blog> GetLast5BlogsWithAuthor()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).OrderByDescending(x => x.Id).Take(5).ToList();
            return values;
        }
    }
}
