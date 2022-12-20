using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class OpcjeWyzywienia
    {
        [Key]
        public int OpcjeWyzywieniaId { get; set; }
        //[Required]
        [MinLength(2, ErrorMessage = "too short name")]
        [Display(Name = "Nazwa opcji wyzywienia")]
        [MaxLength(20, ErrorMessage = "too long name, do not exceed {1}")]
        public string Nazwa_opcji_wyzyw { get; set; }
    }
}
