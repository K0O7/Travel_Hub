using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class RodzajePokoi
    {
        [Key]
        public int RodzajePokoiId { get; set; }
        //[Required]
        //[MinLength(2, ErrorMessage = "too short name")]
        //[Display(Name = "Rodzaj pokoju")]
        //[MaxLength(20, ErrorMessage = "too long name, do not exceed {1}")]
        public string Nazwa_rodzaju_pokoju { get; set; }
        public int Pojemnosc { get; set; }
    }
}
