using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CommentResults
{
    public class GetCommentCountByBlogIdQueryResult
    {
        public int CommentCount { get; set; }
        public int BlogId { get; set; }
    }
}
