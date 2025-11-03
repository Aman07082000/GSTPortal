using System;
using System.ComponentModel.DataAnnotations;

namespace GSTPortal.Models
{
    public class SubscriptionTier
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }    // Free, Silver, Gold...
        public decimal MonthlyPrice { get; set; }
        public string Description { get; set; }
    }

    public class Jurisdiction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string State { get; set; }
        public string Zone { get; set; }
        public string Division { get; set; }
        public string Circle { get; set; }
        public string District { get; set; }
    }

    public enum DocumentType { Act, Rule, Notification, Circular, Guideline }

    public class RegulationDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DocumentType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class Judgment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Court { get; set; }
        public string FullText { get; set; }
        public string Summary { get; set; }  // AI generated
        public string Keywords { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Grievance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Open"; // Open, InProgress, Resolved
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string GatewayReference { get; set; }
        public string Status { get; set; } // Pending, Completed, Failed
    }
}