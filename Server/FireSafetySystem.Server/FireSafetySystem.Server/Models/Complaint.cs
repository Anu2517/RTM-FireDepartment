namespace FireSafetySystem.Server.Models
{
    using System;

    public class Complaint
    {
        public int ComplaintId { get; set; }
        public int UserId { get; set; } // Who submitted the complaint
        public string Description { get; set; } // Details of the complaint
        public string Status { get; set; } // Pending, Investigating, Resolved
        public DateTime SubmittedAt { get; set; } // Date of submission

        // Navigation properties
        public virtual User User { get; set; } // Assuming there is a User class
    }

}
