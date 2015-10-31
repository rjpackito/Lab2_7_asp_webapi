using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2_7_asp_webapi.Models
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }
        public string FilmName{ get;set;}
        public virtual ICollection<Seance> Seance { get; set; }

    }
}
