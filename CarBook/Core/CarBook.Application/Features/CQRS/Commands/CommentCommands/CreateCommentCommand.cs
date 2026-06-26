using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string? Email { get; set; }
        public int BlogId { get; set; }
    }
}
