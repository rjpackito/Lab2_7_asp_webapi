using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using lab2_7_asp_webapi.Models;

namespace lab2_7_asp_webapi.Models
{
    public class AfficheContext : DbContext
    {
        public AfficheContext()
            : base("AfficheContext")
        {

        }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Film> Films { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
