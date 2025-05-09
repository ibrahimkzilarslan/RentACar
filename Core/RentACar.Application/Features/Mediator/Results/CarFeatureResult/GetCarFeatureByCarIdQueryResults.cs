using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarFeatureResult
{
    public class GetCarFeatureByCarIdQueryResults 
    {
        public int CarFeaturesID { get; set; }
        public int FeaturesID { get; set; }
        public string FeaturesName { get; set; }
        public bool Available { get; set; }
    }
}
