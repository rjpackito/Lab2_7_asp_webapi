using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lab2_7_asp_webapi.Models;

namespace lab2_7_asp_webapi.Controllers
{
    public class SeanceController : ApiController
    {
        private AfficheContext db = new AfficheContext();

        // GET: api/Seance
        public IList<SeanceDetailsDTO> GetSeances()
        {
            
            return db.Seances.Select(s => new SeanceDetailsDTO
            {
                SeanceId = s.SeanceId,
                CinemaId = s.Cinema.CinemaId,
                FilmId = s.Film.FilmId,
                SeanceDT = s.SeanceDT,
                CinemaName = s.Cinema.CinemaName,
                FilmName = s.Film.FilmName
            }).ToList();
        }

        // GET: api/Seance/5
        [ResponseType(typeof(SeanceDetailsDTO))]
        public IHttpActionResult GetSeance(int id)
        {
            IList<SeanceDetailsDTO> seance= db.Seances.Select(s => new SeanceDetailsDTO
            {
                SeanceId = s.SeanceId,
                CinemaId = s.Cinema.CinemaId,
                FilmId = s.Film.FilmId,
                SeanceDT = s.SeanceDT,
                CinemaName= s.Cinema.CinemaName,
                FilmName = s.Film.FilmName
            }).Where(s=> s.SeanceId==id).ToList();
            if (seance == null)
            {
                return NotFound();
            }
            
            return Ok(seance);
        }

        // PUT: api/Seance/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeance(int id, Seance seance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seance.SeanceId)
            {
                return BadRequest();
            }

            db.Entry(seance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(id))
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

        // POST: api/Seance
        [ResponseType(typeof(Seance))]
        public IHttpActionResult PostSeance(Seance seance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seances.Add(seance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seance.SeanceId }, seance);
        }

        // DELETE: api/Seance/5
        [ResponseType(typeof(Seance))]
        public IHttpActionResult DeleteSeance(int id)
        {
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return NotFound();
            }

            db.Seances.Remove(seance);
            db.SaveChanges();

            return Ok(seance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeanceExists(int id)
        {
            return db.Seances.Count(e => e.SeanceId == id) > 0;
        }
    }
}