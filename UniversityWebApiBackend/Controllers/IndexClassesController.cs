using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityWebApiBackend.DataAccess;
using UniversityWebApiBackend.Models.DataModels;

namespace UniversityWebApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexClassesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public IndexClassesController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/IndexClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndexClass>>> GetIndexClasses()
        {
          if (_context.IndexClasses == null)
          {
              return NotFound();
          }
            return await _context.IndexClasses.ToListAsync();
        }

        // GET: api/IndexClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IndexClass>> GetIndexClass(int id)
        {
          if (_context.IndexClasses == null)
          {
              return NotFound();
          }
            var indexClass = await _context.IndexClasses.FindAsync(id);

            if (indexClass == null)
            {
                return NotFound();
            }

            return indexClass;
        }

        // PUT: api/IndexClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndexClass(int id, IndexClass indexClass)
        {
            if (id != indexClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(indexClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndexClassExists(id))
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

        // POST: api/IndexClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IndexClass>> PostIndexClass(IndexClass indexClass)
        {
          if (_context.IndexClasses == null)
          {
              return Problem("Entity set 'UniversityDBContext.IndexClasses'  is null.");
          }
            _context.IndexClasses.Add(indexClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndexClass", new { id = indexClass.Id }, indexClass);
        }

        // DELETE: api/IndexClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndexClass(int id)
        {
            if (_context.IndexClasses == null)
            {
                return NotFound();
            }
            var indexClass = await _context.IndexClasses.FindAsync(id);
            if (indexClass == null)
            {
                return NotFound();
            }

            _context.IndexClasses.Remove(indexClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IndexClassExists(int id)
        {
            return (_context.IndexClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
