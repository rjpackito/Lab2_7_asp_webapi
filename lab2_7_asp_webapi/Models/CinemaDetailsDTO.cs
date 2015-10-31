using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7_asp_webapi.Models
{
   public class CinemaDetailsDTO
    {
       public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public List<Seance> Seance { get; set; }
    }
}
