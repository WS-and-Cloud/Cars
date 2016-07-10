using System.ComponentModel.DataAnnotations;
using Cars.Models.Models;

namespace Cars.Models
{
    public class Ad : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public int VehiclesCount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
