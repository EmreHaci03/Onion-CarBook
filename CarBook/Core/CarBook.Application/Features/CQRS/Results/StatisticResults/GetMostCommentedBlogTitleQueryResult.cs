using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.StatisticResults
{
    public class GetMostCommentedBlogTitleQueryResult
    {
        public int CommentCount { get; set; }
        public string BlogTitle { get; set; }
    }
}
