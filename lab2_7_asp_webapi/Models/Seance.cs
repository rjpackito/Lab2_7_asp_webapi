using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2_7_asp_webapi.Models
{
   public class Seance
   {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeanceId { get; set; }
        public int CinemaId { get; set; }
        public int FilmId { get; set; }
        public DateTime SeanceDT { get; set; }
        public Cinema Cinema { get; set; }
        public Film Film { get; set; }

    }
}
