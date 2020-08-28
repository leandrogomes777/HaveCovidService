using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HaveCovidService.Models;

namespace HaveCovidService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithCovidReportsController : ControllerBase
    {
        private readonly HaveCovidContext _context;

        public WithCovidReportsController(HaveCovidContext context)
        {
            _context = context;
        }

        // GET: api/WithCovidReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WithCovidReport>>> GetWithCovidReportItems()
        {
            return await _context.WithCovidReportItems.ToListAsync();
        }

        // GET: api/WithCovidReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WithCovidReport>> GetWithCovidReport(long id)
        {
            var withCovidReport = await _context.WithCovidReportItems.FindAsync(id);

            if (withCovidReport == null)
            {
                return NotFound();
            }

            return withCovidReport;
        }

        // PUT: api/WithCovidReports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWithCovidReport(long id, WithCovidReport withCovidReport)
        {
            if (id != withCovidReport.ID)
            {
                return BadRequest();
            }

            _context.Entry(withCovidReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WithCovidReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WithCovidReports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WithCovidReport>> PostWithCovidReport(WithCovidReport withCovidReport)
        {
            _context.WithCovidReportItems.Add(withCovidReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWithCovidReport", new { id = withCovidReport.ID }, withCovidReport);
        }

        // DELETE: api/WithCovidReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WithCovidReport>> DeleteWithCovidReport(long id)
        {
            var withCovidReport = await _context.WithCovidReportItems.FindAsync(id);
            if (withCovidReport == null)
            {
                return NotFound();
            }

            _context.WithCovidReportItems.Remove(withCovidReport);
            await _context.SaveChangesAsync();

            return withCovidReport;
        }

        private bool WithCovidReportExists(long id)
        {
            return _context.WithCovidReportItems.Any(e => e.ID == id);
        }
    }
}
