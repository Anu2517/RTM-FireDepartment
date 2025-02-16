namespace FireSafetySystem.Server.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public int ApplicationId { get; set; } // Foreign key linking to the application
        public int InspectorId { get; set; } // Assigned inspector
        public string Status { get; set; } // Pending, Completed, Failed
        public string Report { get; set; } // Inspection findings
        public DateTime InspectedAt { get; set; } // Inspection date

        // Navigation properties
        public virtual Application Application { get; set; }
        public virtual User Inspector { get; set; } // Assuming there is a User class
    }

}
