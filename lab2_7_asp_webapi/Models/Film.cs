using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace lab2_7_asp_webapi.Models
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }
        [Required(ErrorMessage = "Поле Название фильма должно быть заполнено.")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z0-9]+([\s][а-яА-ЯёЁa-zA-Z0-9]+)*$", ErrorMessage = "Неверный формат данных")]
        public string FilmName{ get;set;}
        public virtual ICollection<Seance> Seance { get; set; }

    }
}
