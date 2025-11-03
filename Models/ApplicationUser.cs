using Microsoft.AspNetCore.Identity;

namespace GSTPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public Guid? JurisdictionId { get; set; }
        public Guid? SubscriptionTierId { get; set; }
    }
}