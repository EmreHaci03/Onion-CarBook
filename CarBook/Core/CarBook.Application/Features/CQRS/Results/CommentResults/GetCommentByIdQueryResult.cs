using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CommentResults
{
    public class GetCommentByIdQueryResult
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
