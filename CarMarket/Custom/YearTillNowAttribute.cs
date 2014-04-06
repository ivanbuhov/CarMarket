using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMarket.Custom
{
    public class YearTillNowAttribute : ValidationAttribute
    {
        public int MinYear { get; private set; }

        public YearTillNowAttribute(int minYear)
        {
            int currentYear = DateTime.Now.Year;
            if (minYear > currentYear)
            {
                throw new ArgumentOutOfRangeException("minYear", "The min year value must not be greater than the current year.");
            }
            this.MinYear = minYear;
        }

        public override bool IsValid(object value)
        {
            int? yearValue = value as int?;
            return (yearValue != null && yearValue >= this.MinYear && yearValue <= DateTime.Now.Year) ;
        }
    }
}