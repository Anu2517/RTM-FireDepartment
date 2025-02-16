using FireSafetySystem.Server.Database;
using FireSafetySystem.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireSafetySystem.Server.Controllers
{
    [Authorize] // Requires a valid JWT token
    [ApiController]
    [Route("api/applications")]
    public class ApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody] Application application)
        {
            application.SubmittedAt = DateTime.UtcNow;
            application.Status = "Pending Review";
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetApplication), new { id = application.AppId }, application);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();
            return Ok(application);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationStatus(int id, [FromBody] string status)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return NotFound();
            application.Status = status;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
