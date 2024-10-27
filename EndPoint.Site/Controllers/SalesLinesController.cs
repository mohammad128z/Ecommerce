using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Contexts.EF_Core;
using Application.Dtos;
using Mapster;

namespace EndPoint.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesLinesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public SalesLinesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/SalesLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesLine>>> GetSalesLine()
        {
            return await _context.SalesLine.ToListAsync();
        }

        // GET: api/SalesLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesLine>> GetSalesLine(int id)
        {
            var salesLine = await _context.SalesLine.FindAsync(id);

            if (salesLine == null)
            {
                return NotFound();
            }

            return salesLine;
        }

        // PUT: api/SalesLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesLine(int id, SalesLine salesLine)
        {
            if (id != salesLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesLineExists(id))
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

        // POST: api/SalesLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesLine>> PostSalesLine(SalesLineDto Dto)
        {
            var NewSalesLine = Dto.Adapt<SalesLine>();
            _context.SalesLine.Add(NewSalesLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesLine", new { id = NewSalesLine.Id }, NewSalesLine);
        }

        // DELETE: api/SalesLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesLine(int id)
        {
            var salesLine = await _context.SalesLine.FindAsync(id);
            if (salesLine == null)
            {
                return NotFound();
            }

            _context.SalesLine.Remove(salesLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesLineExists(int id)
        {
            return _context.SalesLine.Any(e => e.Id == id);
        }
    }
}
