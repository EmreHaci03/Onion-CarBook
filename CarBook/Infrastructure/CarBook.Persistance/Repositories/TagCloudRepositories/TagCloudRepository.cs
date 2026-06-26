using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _carBookContext;

        public TagCloudRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            return _carBookContext.TagClouds.Where(x=>x.BlogId== id).ToList();
        }

        public List<TagCloud> GetTagCloudsWithBlog()
        {
            return _carBookContext.TagClouds.Include(x => x.Blog).ToList();
        }
    }
}
