namespace lab2_7_asp_webapi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using lab2_7_asp_webapi.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<lab2_7_asp_webapi.Models.AfficheContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "lab2_7_asp_webapi.Models.AfficheContext";
        }

        protected override void Seed(lab2_7_asp_webapi.Models.AfficheContext context)
        {
          
            context.Cinemas.AddOrUpdate(new Cinema() { CinemaName = "Байкал" },
                new Cinema() { CinemaName = "LuxCinema" });
            context.Films.AddOrUpdate(new Film() { FilmName = "Звездные войны" });
         
            context.Seances.AddOrUpdate( new Seance(){FilmId=1,CinemaId=1,SeanceDT=DateTime.Parse("2015-11-01")});
        }
    }
}
