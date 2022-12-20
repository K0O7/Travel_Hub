using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class WybraneWyzywienia
    {
        [Key]
        public int WybraneWyzywieniaId { get; set; }
        //[Required]
        //[ForeignKey("Id_osrodka")]

        public int OsrodkiId { get; set; }
        public Osrodki Osrodki { get; set; }
        //[Required]
        //[ForeignKey("Id_opcji_wyzyw")]

        public int OpcjeWyzywieniaId { get; set; }
        public OpcjeWyzywienia OpcjeWyzywienia { get; set; }

        //public WybraneWyzywienia()
        //{
        //}
        //public WybraneWyzywienia(int idww, int idos, int idow)
        //{
        //    WybraneWyzywieniaId = idww;
        //    OsrodkiId = idos;
        //    OpcjeWyzywieniaId = idow;
        //}
    }
}