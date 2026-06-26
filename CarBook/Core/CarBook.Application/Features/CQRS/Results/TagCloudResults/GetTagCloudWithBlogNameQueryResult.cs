using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.TagCloudResults
{
    public class GetTagCloudWithBlogNameQueryResult
    {
        public int TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}
