using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class OferowanePokoje
    {
        //[Key]
        //[Column(Order = 1)]
        //[ForeignKey("Id_rodzaju_pokoju")]
        public int RodzajePokoiId { get; set; }
        public RodzajePokoi RodzajePokoi { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //[ForeignKey("Id_osrodka")]
        public int OsrodkiId { get; set; }
        public Osrodki Osrodki { get; set; }
    }
}
