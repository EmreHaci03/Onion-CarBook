using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
