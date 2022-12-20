using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class Firma
    {
        [Key]
        public int FirmaId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "too short name")]
        [Display(Name = "Nazwa Firmy")]
        [MaxLength(20, ErrorMessage = "too long name, do not exceed {1}")]
        public string Nazwa_firmy { get; set; }
    }
}
