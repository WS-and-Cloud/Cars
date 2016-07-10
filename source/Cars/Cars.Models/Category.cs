using System.Collections.Generic;
using Cars.Models.Models;

namespace Cars.Models
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
            this.Vehicles = new HashSet<Vehicle>();
        }

        public string Name { get; set; }

        public int AdsCount { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
