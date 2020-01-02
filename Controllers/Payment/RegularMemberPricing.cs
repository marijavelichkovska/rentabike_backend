﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication20.Controllers.Payment
{
    public class RegularMemberPricing : PriceCalculation
    {
        int PriceCalculation.calculatePrice(double minutes)
        {
            return (int)(minutes * 0.5);
        }

    }
}