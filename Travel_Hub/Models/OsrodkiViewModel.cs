using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class Osrodki
    {
        [Key]
        public int OsrodkiId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "too short name")]
        [Display(Name = "Nazwa osrodka")]
        [MaxLength(20, ErrorMessage = "too long name, do not exceed {1}")]
        public string Nazwa_osrodka { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "too short name")]
        [MaxLength(40, ErrorMessage = "too long name, do not exceed {1}")]
        public string Adres { get; set; }
        public string Zdjecie { get; set; }
    }
}
