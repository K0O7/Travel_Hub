using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    //enum stan rezerwacji
    public enum StanWycieczki {Potwierdzona, Anulowana, Polaczona }
    public class Wycieczka
    {
        [Key]
        public int WycieczkaId { get; set; }
        [Required]
        public int Max_osob { get; set; }
        [Required]
        public float Cena { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public StanWycieczki Stan { get; set; }
        //[Required]
        //[ForeignKey("Id_pracownika")]
        //public int Id_pracownika_f { get; set; }
        //[ForeignKey("Id_osrodka")]
        public int OsrodkiId { get; set; }
        public Osrodki Osrodki { get; set; }
    }
}
