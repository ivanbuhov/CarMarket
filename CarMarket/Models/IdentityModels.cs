using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CarMarket.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Offers = new HashSet<Offer>();
        }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}