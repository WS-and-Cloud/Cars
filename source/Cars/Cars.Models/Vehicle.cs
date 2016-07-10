using System;
using System.ComponentModel.DataAnnotations;
using Cars.Models.Models;

namespace Cars.Models
{
    public class Vehicle : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Power { get; set; }

        public string Colour { get; set; }

        [Range(0, int.MaxValue)]
        public float RunInKm { get; set; }

        public DateTime DateManufactured { get; set; }

        public EngineType EngineType { get; set; }

        public VehicleTypes VehicleType { get; set; }
    }
}
