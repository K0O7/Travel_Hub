using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class OfertaFirmy
    {
        //[Key]
        //[ForeignKey("Id_firmy")]
        //[Column(Order = 1)]
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }
        //[Key]
        //[ForeignKey("Id_wycieczki")]
        //[Column(Order = 2)]
        public int WycieczkaId { get; set; }
        public Wycieczka Wycieczka { get; set; }
    }
}
