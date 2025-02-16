namespace FireSafetySystem.Server.Database
{
    using FireSafetySystem.Server.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
    }

}
