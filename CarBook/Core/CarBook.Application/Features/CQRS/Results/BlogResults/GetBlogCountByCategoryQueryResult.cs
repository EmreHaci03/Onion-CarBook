using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.BlogResults
{
    public class GetBlogCountByCategoryQueryResult
    {
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
