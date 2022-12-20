using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Models
{
    //enum stan rezerwacji
    public enum StatusRezerwacji { Oczekuje_na_oplate,Potwierdzona,Anulowana,Zaplacona_zaliczka}
    public class Rezerwacja
    {
        [Key]
        public int RezerwacjaId { get; set; }
        //[Required]
        public string Data_zlorzenia { get; set; }
        //[Required]
        public StatusRezerwacji Status { get; set; }
        //[Required]
        public float Zaliczka { get; set; }
        //[Required]
        public int Liczba_uczestnikow { get; set; }
        //[Required]
        public string Dane_osobowe { get; set; }
        //[ForeignKey("Id_wycieczki")]
        public int WycieczkaId { get; set; }
        public Wycieczka Wycieczka { get; set; }
        //[ForeignKey("Id_rezerwacji_pokoju")]
        //[Required]
        public int WybranePokojeId { get; set; }
        public WybranePokoje WybranePokoje { get; set; }
        //[ForeignKey("Id_wybranego_wyzywienia")]
        //[Required]
        public int WybraneWyzywieniaId { get; set; }
        public WybraneWyzywienia WybraneWyzywienia { get; set; }
        //[ForeignKey("Wybrane_miejsce_startu")]
        //[Required]
        public int OferowaneMiejscaStartuId { get; set; }
        public OferowaneMiejscaStartu OferowaneMiejscaStartu { get; set; }
        //[ForeignKey("UserId")]
        //[Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        //public Rezerwacja()
        //{
        //}

        //    public Rezerwacja(int idR, string data, float zal, int lu, string DaneOs, int WId, int wpId, int wwId, int omsId, string userId, StatusRezerwacji Stat = StatusRezerwacji.Oczekuje_na_oplate)
        //{
        //    RezerwacjaId = idR;
        //    Data_zlorzenia = data;
        //    Zaliczka = zal;
        //    Liczba_uczestnikow = lu;
        //    Dane_osobowe = DaneOs;
        //    WycieczkaId = WId;
        //    WybranePokojeId = wpId;
        //    WybraneWyzywieniaId = wwId;
        //    OferowaneMiejscaStartuId = omsId;
        //    UserId = userId;
        //    Status = Stat;
        //}
    }
}
