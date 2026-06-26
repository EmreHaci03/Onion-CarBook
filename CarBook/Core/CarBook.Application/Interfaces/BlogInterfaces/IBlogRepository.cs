using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogsWithDetails();

        Blog GetBlogsWithDetailsByBlogId(int id);

        List<Blog> GetLast3BlogsWithAuthor();

        List<Blog> GetLast5BlogsWithAuthor();

        List<Blog> GetBlogCountByCategoryQuery();


    }
}
