using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace lab2_mvcWEBapi.Models
{
    class AfishaContext:DbContext
    {
        public DbSet<Afisha> Afishs { get; set;}
        public DbSet<Kino> Kinos { get; set; }
        public DbSet<Films> Filmss { get; set; } 
    }
}
