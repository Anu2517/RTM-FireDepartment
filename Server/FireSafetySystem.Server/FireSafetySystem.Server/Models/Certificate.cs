namespace FireSafetySystem.Server.Models
{

    public class Certificate
    {
        public int CertificateId { get; set; }
        public int ApplicationId { get; set; } // Foreign key linking to the application
        public int IssuedBy { get; set; } // Officer who issued the certificate
        public DateTime IssuedAt { get; set; } // Issue date
        public DateTime ExpiresAt { get; set; } // Expiry date

        // Navigation properties
        public virtual Application Application { get; set; }
        public virtual User Officer { get; set; } // Assuming there is a User class
    }

}
