using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class OferowaneWyzywienia
    {
        //[Key]
        //[ForeignKey("Id_osrodka")]
        //[Column(Order =1)]
        public int OsrodkiId { get; set; }
        public Osrodki Osrodki { get; set; }
        //[Key]
        //[ForeignKey("Id_osrodka")]
        //[Column(Order = 2)]
        public int OpcjeWyzywieniaId { get; set; }
        public OpcjeWyzywienia OpcjeWyzywienia { get; set; }
    }
}
