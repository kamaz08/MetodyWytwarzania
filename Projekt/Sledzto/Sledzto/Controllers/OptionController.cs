using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sledzto;
using Sledzto.Models;

namespace Sledzto.Controllers
{
    public class OptionController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/Option
        public IQueryable<Option> GetOptions()
        {
            return db.Options;
        }

        // GET: api/Option/5
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> GetOption(int id)
        {
            Option option = await db.Options.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // PUT: api/Option/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOption(int id, Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.Id)
            {
                return BadRequest();
            }

            db.Entry(option).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Option
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> PostOption(Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Options.Add(option);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = option.Id }, option);
        }

        // DELETE: api/Option/5
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> DeleteOption(int id)
        {
            Option option = await db.Options.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            db.Options.Remove(option);
            await db.SaveChangesAsync();

            return Ok(option);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OptionExists(int id)
        {
            return db.Options.Count(e => e.Id == id) > 0;
        }
    }
}