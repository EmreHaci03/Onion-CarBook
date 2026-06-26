using CarBook.Application.Features.CQRS.Results.BannerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery:IRequest<GetBannerByIdQueryResult>
    {
        public GetBannerByIdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
