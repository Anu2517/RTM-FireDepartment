namespace FireSafetySystem.Server.Models
{
    public class Application
    {
        public int AppId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } // NOC, Inspection, Renewal, Complaint
        public string Status { get; set; } // Pending Review, Approved, Rejected
        public DateTime SubmittedAt { get; set; }
        public User User { get; set; }
    }

}
