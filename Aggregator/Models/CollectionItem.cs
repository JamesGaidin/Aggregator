using System;

namespace Aggregator.Models
{
    public class CollectionItem
    {
        public Guid Id { get; set; } = new Guid();
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;

        // Core item data
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        // Creator details
        public string CreatorName { get; set; }
        public string CreatorOrigin { get; set; }
        public string CreatorContactInfo { get; set; }

        // Value + acquisition
        public decimal EstimatedValue { get; set; }
        public DateTime DateAcquired { get; set; }
        public string PurchaseSource { get; set; }
        public string PurchasePrice { get; set; }
        public string Condition { get; set; }
        public string Provenance { get; set; } // History of ownership
        public string AuthenticationDetails { get; set; } // Certificates, appraisals, etc.

        // Location + insurance
        public string Location { get; set; }
        public string InsuranceAgent { get; set; }
        public string InsurancePolicy { get; set; }
        public string InsuranceContactInfo { get; set; }

        // Metadata
        public string Tags { get; set; }
        public string Notes { get; set; }
    }
}
