using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace lab2_7_asp_webapi.Models
{
   public class Cinema
   {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public virtual ICollection<Seance> Seance { get; set; }
    }
}
