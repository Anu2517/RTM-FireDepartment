using FireSafetySystem.Server.Database;
using FireSafetySystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireSafetySystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComplaintsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> FileComplaint([FromBody] Complaint complaint)
        {
            complaint.SubmittedAt = DateTime.UtcNow;
            complaint.Status = "Pending";
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(FileComplaint), new { id = complaint.ComplaintId }, complaint);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateComplaintStatus(int id, [FromBody] string status)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null) return NotFound();
            complaint.Status = status;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
