using CarMarket.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CarMarket.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Title { get; set; }

        [Display(Name = "Date published")]
        public DateTime DatePublished { get; set; }

        [Required]
        [Display(Name = "Region(country, city etc.)")]
        public string Region { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address(for contact)")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number(for contact)")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Range(5, 10000)]
        public int Hoursepowers { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        public Color Color { get; set; }

        [YearTillNow(1850)]
        [Display(Name = "Manufacture year")]
        public int Year { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Traveled (km)")]
        public int Kilometers { get; set; }

        [Range(1, 6)]
        [Display(Name = "Doors count")]
        public int DoorsCount { get; set; }

        // Extras
        public bool GPS { get; set; }
        [Display(Description = "Anti-blocking system")]

        public bool ABS { get; set; }

        public bool Airbag { get; set; }

        public bool Parktronic { get; set; }

        [Display(Name = "Board computer")]
        public bool BoardComputer { get; set; }

        [Display(Name = "Air conditioning")]
        public bool AirConditioning { get; set; }

        public bool Climatronic { get; set; }

        [Display(Name = "Rain sensor")]
        public bool RainSensor { get; set; }

        [Display(Name = "Power assisted steering")]
        public bool PowerАssistedSteering { get; set; }

        public bool Stereo { get; set; }

        [Display(Name = "4x4")]
        public bool FourByFour { get; set; }

        [Display(Name = "Gas system")]
        public bool GasSystem { get; set; }

        [Display(Name = "Methane system")]
        public bool MethaneSystem { get; set; }

        public bool Tuning { get; set; }
    }
}
