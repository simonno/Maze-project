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
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class DefaultArgsController : ApiController
    {
        private WebMazeContext db = new WebMazeContext();

        // GET: api/DefaultArgs
        public IQueryable<DefaultArgs> GetDefaultArgs()
        {
            return db.DefaultArgs;
        }

        // GET: api/DefaultArgs/5
        [ResponseType(typeof(DefaultArgs))]
        public async Task<IHttpActionResult> GetDefaultArgs(int id)
        {
            DefaultArgs defaultArgs = await db.DefaultArgs.FindAsync(id);
            if (defaultArgs == null)
            {
                return NotFound();
            }

            return Ok(defaultArgs);
        }

        // PUT: api/DefaultArgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDefaultArgs(int id, DefaultArgs defaultArgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defaultArgs.Id)
            {
                return BadRequest();
            }

            db.Entry(defaultArgs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefaultArgsExists(id))
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

        // POST: api/DefaultArgs
        [ResponseType(typeof(DefaultArgs))]
        public async Task<IHttpActionResult> PostDefaultArgs(DefaultArgs defaultArgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DefaultArgs.Add(defaultArgs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = defaultArgs.Id }, defaultArgs);
        }

        // DELETE: api/DefaultArgs/5
        [ResponseType(typeof(DefaultArgs))]
        public async Task<IHttpActionResult> DeleteDefaultArgs(int id)
        {
            DefaultArgs defaultArgs = await db.DefaultArgs.FindAsync(id);
            if (defaultArgs == null)
            {
                return NotFound();
            }

            db.DefaultArgs.Remove(defaultArgs);
            await db.SaveChangesAsync();

            return Ok(defaultArgs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefaultArgsExists(int id)
        {
            return db.DefaultArgs.Count(e => e.Id == id) > 0;
        }
    }
}