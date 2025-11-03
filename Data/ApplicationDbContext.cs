using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GSTPortal.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GSTPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<SubscriptionTier> SubscriptionTiers { get; set; }
        public DbSet<Jurisdiction> Jurisdictions { get; set; }
        public DbSet<RegulationDocument> RegulationDocuments { get; set; }
        public DbSet<Judgment> Judgments { get; set; }
        public DbSet<Grievance> Grievances { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // seed subscription tiers maybe
            builder.Entity<SubscriptionTier>().HasData(
                new SubscriptionTier { Id = Guid.NewGuid(), Name = "Free", MonthlyPrice = 0, Description = "Basic access" },
                new SubscriptionTier { Id = Guid.NewGuid(), Name = "Silver", MonthlyPrice = 499, Description = "Silver tier" },
                new SubscriptionTier { Id = Guid.NewGuid(), Name = "Gold", MonthlyPrice = 999, Description = "Gold tier" }
            );
        }
    }
}
