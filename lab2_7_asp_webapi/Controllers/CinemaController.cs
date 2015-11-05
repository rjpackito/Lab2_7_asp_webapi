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
using System.Text.RegularExpressions;

namespace lab2_7_asp_webapi.Controllers
{
    public class CinemaController : ApiController
    {
        private AfficheContext db = new AfficheContext();

        // GET: api/Cinema
        public IQueryable<CinemaDetailsDTO> GetCinemas()
        {
            return db.Cinemas.Select(c => new CinemaDetailsDTO
            { 
                CinemaId=c.CinemaId,
                CinemaName = c.CinemaName
            });
        }

        // GET: api/Cinema/5
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult GetCinema(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        // PUT: api/Cinema/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinema(int id, Cinema cinema)
        {
            string pattern = @"^[а-яА-ЯёЁa-zA-Z0-9]+([\s][а-яА-ЯёЁa-zA-Z0-9])*$";
            string entry = "";
            entry = Regex.Replace(cinema.CinemaName, pattern, String.Empty);
            if (!ModelState.IsValid || cinema.CinemaName == "" || entry != "")
            {
                return BadRequest(ModelState);
            }

            if (id != cinema.CinemaId)
            {
                return BadRequest();
            }

            db.Entry(cinema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaExists(id))
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

        // POST: api/Cinema
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult PostCinema(Cinema cinema)
        {
            string pattern = @"^[а-яА-ЯёЁa-zA-Z0-9]+([\s][а-яА-ЯёЁa-zA-Z0-9])*$";
            string entry = "";
            entry = Regex.Replace(cinema.CinemaName, pattern, String.Empty);
            if (!ModelState.IsValid || cinema.CinemaName == "" || entry != "")
            {
                return BadRequest(ModelState);
            }

            db.Cinemas.Add(cinema);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinema.CinemaId }, cinema);
        }

        // DELETE: api/Cinema/5
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult DeleteCinema(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            db.Cinemas.Remove(cinema);
            db.SaveChanges();

            return Ok(cinema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinemaExists(int id)
        {
            return db.Cinemas.Count(e => e.CinemaId == id) > 0;
        }
    }
}