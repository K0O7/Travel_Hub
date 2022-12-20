using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    public class OferowaneMiejscaStartu
    {
        [Key]
        public int OferowaneMiejscaStartuId { get; set; }
        //[ForeignKey("Id_miejsca")]
        public int MiejscaStartuId { get; set; }
        public MiejscaStartu MiejscaStartu { get; set; }
        //[ForeignKey("Id_wycieczki")]
        public int WycieczkaId { get; set; }
        public Wycieczka Wycieczka { get; set; }
    }
}
