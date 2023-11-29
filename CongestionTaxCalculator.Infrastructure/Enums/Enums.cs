using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CongestionTaxCalculator.Infrastructure.Enums
{
    public enum CurrencyType
    {
        [Display(Name = "SEK")]
        SEK,
        [Display(Name = "EURO")]
        EURO,
        [Display(Name = "DOLLAR")]
        DOLLAR,
        [Display(Name = "LIR")]
        LIR
    }
}
