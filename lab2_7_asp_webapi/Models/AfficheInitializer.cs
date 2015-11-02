using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using lab2_7_asp_webapi.Models;

namespace lab2_7_asp_webapi.Models
{
   public class AfficheInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AfficheContext>
    {
        protected override void Seed(AfficheContext context)
        {
            var cinemas=new List<Cinema>{
                new Cinema{CinemaName="Байкал"},
                new Cinema{CinemaName="LuxCinema"}
            };
            cinemas.ForEach(s => context.Cinemas.Add(s));
            context.SaveChanges();
            var films = new List<Film>{
                new Film{FilmName="Звездные войны"}
            };
            films.ForEach(s => context.Films.Add(s));
            context.SaveChanges();
            var seances = new List<Seance>{
                new Seance{FilmId=1,CinemaId=1,SeanceDT=DateTime.Parse("2015-11-01")}
            };
            seances.ForEach(s => context.Seances.Add(s));
            context.SaveChanges();
        }
    }
}
