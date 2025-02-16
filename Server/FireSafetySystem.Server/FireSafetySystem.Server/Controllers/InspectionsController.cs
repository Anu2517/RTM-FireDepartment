using FireSafetySystem.Server.Database;
using FireSafetySystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireSafetySystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InspectionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AssignInspector([FromBody] Inspection inspection)
        {
            inspection.Status = "Pending";
            inspection.InspectedAt = DateTime.UtcNow;
            _context.Inspections.Add(inspection);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AssignInspector), new { id = inspection.InspectionId }, inspection);
        }

        [HttpPut("{id}/report")]
        public async Task<IActionResult> SubmitInspectionReport(int id, [FromBody] string report)
        {
            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection == null) return NotFound();
            inspection.Report = report;
            inspection.Status = "Completed";
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
