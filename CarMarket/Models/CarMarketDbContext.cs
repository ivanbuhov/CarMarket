using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarMarket.Models
{
    public class CarMarketDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarMarketDbContext()
            : base("CarMarketDbConnection")
        {
        }

        public IDbSet<Offer> Offers { get; set; }
    }
}