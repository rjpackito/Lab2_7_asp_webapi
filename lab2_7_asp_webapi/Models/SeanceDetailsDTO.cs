using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7_asp_webapi.Models
{
    public class SeanceDetailsDTO
    {
        public int SeanceId { get; set; }
        public int CinemaId { get; set; }
        public int FilmId { get; set; }
        public string CinemaName { get; set; }
        public string FilmName { get; set; }
        public DateTime SeanceDT { get; set; }

    }
}
