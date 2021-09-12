using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Signaler.Data.Contexts;
using Signaler.Library.Data.Core;
using Signaler.Data.Models;
using Signaler.Library.Services;

namespace GenericCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase<T> : ControllerBase where T : BaseEntity
    {
        protected readonly signalContext _context;
        protected readonly IService<T> _service;

        public ApiControllerBase(IService<T> service)
        {
            this._service = service;
        }

        public ApiControllerBase(signalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var entities = await _context.Set<T>().ToListAsync();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Detail(long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T entity)
        {
            entity.CreationDate = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Detail", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(long id, T entity)
        {
            if (id != entity.Id)
                return BadRequest();

            if (!await EntityExists(id))
                return NotFound();

            entity.ModificationDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return NotFound();

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> EntityExists(long id)
        {
            return _context.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}