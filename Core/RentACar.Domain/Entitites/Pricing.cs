﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entitites
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
