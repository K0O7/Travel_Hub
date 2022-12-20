using Travel_Hub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Hub.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<MiejscaStartu> MiejscaStartu { get; set; }
        public DbSet<OferowaneMiejscaStartu> OferowaneMiejscaStartu { get; set; }
        public DbSet<OferowanePokoje> OferowanePokoje { get; set; }
        public DbSet<OferowaneWyzywienia> OferowaneWyzywienia { get; set; }
        public DbSet<OfertaFirmy> OfertaFirmy { get; set; }
        public DbSet<OpcjeWyzywienia> OpcjeWyzywienia { get; set; }
        public DbSet<Osrodki> Osrodki { get; set; }
        public DbSet<Rezerwacja> Rezerwacja { get; set; }
        public DbSet<RodzajePokoi> RodzajePokoi { get; set; }
        public DbSet<WybranePokoje> WybranePokoje { get; set; }
        public DbSet<WybraneWyzywienia> WybraneWyzywienia { get; set; }
        public DbSet<Wycieczka> Wycieczka { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OferowaneWyzywienia>()
                .HasKey(t => new { t.OpcjeWyzywieniaId, t.OsrodkiId });
            modelBuilder.Entity<OferowanePokoje>()
                .HasKey(t => new { t.OsrodkiId, t.RodzajePokoiId });
            modelBuilder.Entity<OfertaFirmy>()
               .HasKey(t => new { t.FirmaId, t.WycieczkaId });
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
    //public static class ModelBuilderExtension
    //{
    //    public static void Seed(this ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<KlientViewModel>().HasData(
    //            new KlientViewModel()
    //            {
    //                KlientId = 1,
    //                Mail = "mail@gmail.com",
    //                Password = "qwerty",
    //                Status = Status.klient
    //            },
    //            new KlientViewModel()
    //            {
    //                KlientId = 2,
    //                Mail = "admin@gmail.com",
    //                Password = "password",
    //                Status = Status.administrator
    //            });

    //    }
    //}
}
