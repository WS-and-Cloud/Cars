using System;
using System.Data.Entity;
using System.Linq;
using Cars.Models;
using Cars.Models.Models;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Cars.Data
{
    public class CarsDbContext : IdentityDbContext<User>
    {
        public CarsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public IDbSet<Ad> Ads { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Vehicle> Vehicles { get; set; }

        public static CarsDbContext Create()
        {
            return new CarsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
