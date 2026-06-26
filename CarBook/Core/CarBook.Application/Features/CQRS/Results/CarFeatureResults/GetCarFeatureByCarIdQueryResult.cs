using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }

        public bool Avaliable { get; set; }
    }
}
