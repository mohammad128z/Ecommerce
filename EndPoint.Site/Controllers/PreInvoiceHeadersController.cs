using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Contexts.EF_Core;

namespace EndPoint.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreInvoiceHeadersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PreInvoiceHeadersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/PreInvoiceHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreInvoiceHeader>>> GetPreInvoiceHeader()
        {
            return await _context.PreInvoiceHeader.ToListAsync();
        }

        // GET: api/PreInvoiceHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreInvoiceHeader>> GetPreInvoiceHeader(int id)
        {
            var preInvoiceHeader = await _context.PreInvoiceHeader.FindAsync(id);

            if (preInvoiceHeader == null)
            {
                return NotFound();
            }

            return preInvoiceHeader;
        }

        // PUT: api/PreInvoiceHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreInvoiceHeader(int id, PreInvoiceHeader preInvoiceHeader)
        {
            if (id != preInvoiceHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(preInvoiceHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreInvoiceHeaderExists(id))
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

        // POST: api/PreInvoiceHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreInvoiceHeader>> PostPreInvoiceHeader(PreInvoiceHeader preInvoiceHeader)
        {
            _context.PreInvoiceHeader.Add(preInvoiceHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreInvoiceHeader", new { id = preInvoiceHeader.Id }, preInvoiceHeader);
        }

        // DELETE: api/PreInvoiceHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreInvoiceHeader(int id)
        {
            var preInvoiceHeader = await _context.PreInvoiceHeader.FindAsync(id);
            if (preInvoiceHeader == null)
            {
                return NotFound();
            }

            _context.PreInvoiceHeader.Remove(preInvoiceHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreInvoiceHeaderExists(int id)
        {
            return _context.PreInvoiceHeader.Any(e => e.Id == id);
        }
    }
}
