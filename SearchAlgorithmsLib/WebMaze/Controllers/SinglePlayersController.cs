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
    public class SinglePlayersController : ApiController
    {
        private WebMazeContext db = new WebMazeContext();

        // GET: api/SinglePlayers
        public IQueryable<SinglePlayer> GetSinglePlayers()
        {
            return db.SinglePlayers;
        }

        // GET: api/SinglePlayers/5
        [ResponseType(typeof(SinglePlayer))]
        public async Task<IHttpActionResult> GetSinglePlayer(int id)
        {
            SinglePlayer singlePlayer = await db.SinglePlayers.FindAsync(id);
            if (singlePlayer == null)
            {
                return NotFound();
            }

            return Ok(singlePlayer);
        }

        // PUT: api/SinglePlayers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSinglePlayer(int id, SinglePlayer singlePlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != singlePlayer.Id)
            {
                return BadRequest();
            }

            db.Entry(singlePlayer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinglePlayerExists(id))
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

        // POST: api/SinglePlayers
        [ResponseType(typeof(SinglePlayer))]
        public async Task<IHttpActionResult> PostSinglePlayer(SinglePlayer singlePlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SinglePlayers.Add(singlePlayer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = singlePlayer.Id }, singlePlayer);
        }

        // DELETE: api/SinglePlayers/5
        [ResponseType(typeof(SinglePlayer))]
        public async Task<IHttpActionResult> DeleteSinglePlayer(int id)
        {
            SinglePlayer singlePlayer = await db.SinglePlayers.FindAsync(id);
            if (singlePlayer == null)
            {
                return NotFound();
            }

            db.SinglePlayers.Remove(singlePlayer);
            await db.SaveChangesAsync();

            return Ok(singlePlayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SinglePlayerExists(int id)
        {
            return db.SinglePlayers.Count(e => e.Id == id) > 0;
        }
    }
}