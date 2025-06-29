﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResults
    {

        public int CarID { get; set; }
        public int CarPricingID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Amount { get; set; }

        public string CoverImageUrl { get; set; }

    }
}
