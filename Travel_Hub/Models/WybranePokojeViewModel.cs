using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class WybranePokoje
    {
        [Key]
        public int WybranePokojeId { get; set; }
        //[Required]
        //[ForeignKey("Id_osrodka")]
        public int OsrodkiId { get; set; }
        public Osrodki Osrodki { get; set; }
        //[ForeignKey("Id_rodzaju_pokoju")]
        //[Required]
        public int RodzajePokoiId { get; set; }
        public RodzajePokoi RodzajePokoi { get; set; }

        //public WybranePokoje()
        //{
        //}

        //    public WybranePokoje(int idwp, int idos, int idrp)
        //{
        //    WybranePokojeId = idwp;
        //    OsrodkiId = idos;
        //    RodzajePokoiId = idrp;
        //}
    }
}