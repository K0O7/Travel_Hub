﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel_Hub.Data;

namespace Travel_Hub.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220127155122_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Travel_Hub.Models.Firma", b =>
                {
                    b.Property<int>("FirmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa_firmy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FirmaId");

                    b.ToTable("Firma");
                });

            modelBuilder.Entity("Travel_Hub.Models.MiejscaStartu", b =>
                {
                    b.Property<int>("MiejscaStartuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa_miejsca")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MiejscaStartuId");

                    b.ToTable("MiejscaStartu");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowaneMiejscaStartu", b =>
                {
                    b.Property<int>("OferowaneMiejscaStartuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MiejscaStartuId")
                        .HasColumnType("int");

                    b.Property<int>("WycieczkaId")
                        .HasColumnType("int");

                    b.HasKey("OferowaneMiejscaStartuId");

                    b.HasIndex("MiejscaStartuId");

                    b.HasIndex("WycieczkaId");

                    b.ToTable("OferowaneMiejscaStartu");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowanePokoje", b =>
                {
                    b.Property<int>("OsrodkiId")
                        .HasColumnType("int");

                    b.Property<int>("RodzajePokoiId")
                        .HasColumnType("int");

                    b.HasKey("OsrodkiId", "RodzajePokoiId");

                    b.HasIndex("RodzajePokoiId");

                    b.ToTable("OferowanePokoje");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowaneWyzywienia", b =>
                {
                    b.Property<int>("OpcjeWyzywieniaId")
                        .HasColumnType("int");

                    b.Property<int>("OsrodkiId")
                        .HasColumnType("int");

                    b.HasKey("OpcjeWyzywieniaId", "OsrodkiId");

                    b.HasIndex("OsrodkiId");

                    b.ToTable("OferowaneWyzywienia");
                });

            modelBuilder.Entity("Travel_Hub.Models.OfertaFirmy", b =>
                {
                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<int>("WycieczkaId")
                        .HasColumnType("int");

                    b.HasKey("FirmaId", "WycieczkaId");

                    b.HasIndex("WycieczkaId");

                    b.ToTable("OfertaFirmy");
                });

            modelBuilder.Entity("Travel_Hub.Models.OpcjeWyzywienia", b =>
                {
                    b.Property<int>("OpcjeWyzywieniaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa_opcji_wyzyw")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("OpcjeWyzywieniaId");

                    b.ToTable("OpcjeWyzywienia");
                });

            modelBuilder.Entity("Travel_Hub.Models.Osrodki", b =>
                {
                    b.Property<int>("OsrodkiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nazwa_osrodka")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Zdjecie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OsrodkiId");

                    b.ToTable("Osrodki");
                });

            modelBuilder.Entity("Travel_Hub.Models.Rezerwacja", b =>
                {
                    b.Property<int>("RezerwacjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dane_osobowe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data_zlorzenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Liczba_uczestnikow")
                        .HasColumnType("int");

                    b.Property<int>("OferowaneMiejscaStartuId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("WybranePokojeId")
                        .HasColumnType("int");

                    b.Property<int>("WybraneWyzywieniaId")
                        .HasColumnType("int");

                    b.Property<int>("WycieczkaId")
                        .HasColumnType("int");

                    b.Property<float>("Zaliczka")
                        .HasColumnType("real");

                    b.HasKey("RezerwacjaId");

                    b.HasIndex("OferowaneMiejscaStartuId");

                    b.HasIndex("WybranePokojeId");

                    b.HasIndex("WybraneWyzywieniaId");

                    b.HasIndex("WycieczkaId");

                    b.ToTable("Rezerwacja");
                });

            modelBuilder.Entity("Travel_Hub.Models.RodzajePokoi", b =>
                {
                    b.Property<int>("RodzajePokoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa_rodzaju_pokoju")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RodzajePokoiId");

                    b.ToTable("RodzajePokoi");
                });

            modelBuilder.Entity("Travel_Hub.Models.WybranePokoje", b =>
                {
                    b.Property<int>("WybranePokojeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OsrodkiId")
                        .HasColumnType("int");

                    b.Property<int>("RodzajePokoiId")
                        .HasColumnType("int");

                    b.HasKey("WybranePokojeId");

                    b.HasIndex("OsrodkiId");

                    b.HasIndex("RodzajePokoiId");

                    b.ToTable("WybranePokoje");
                });

            modelBuilder.Entity("Travel_Hub.Models.WybraneWyzywienia", b =>
                {
                    b.Property<int>("WybraneWyzywieniaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OpcjeWyzywieniaId")
                        .HasColumnType("int");

                    b.Property<int>("OsrodkiId")
                        .HasColumnType("int");

                    b.HasKey("WybraneWyzywieniaId");

                    b.HasIndex("OpcjeWyzywieniaId");

                    b.HasIndex("OsrodkiId");

                    b.ToTable("WybraneWyzywienia");
                });

            modelBuilder.Entity("Travel_Hub.Models.Wycieczka", b =>
                {
                    b.Property<int>("WycieczkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<int>("Max_osob")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OsrodkiId")
                        .HasColumnType("int");

                    b.Property<int>("Stan")
                        .HasColumnType("int");

                    b.HasKey("WycieczkaId");

                    b.HasIndex("OsrodkiId");

                    b.ToTable("Wycieczka");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowaneMiejscaStartu", b =>
                {
                    b.HasOne("Travel_Hub.Models.MiejscaStartu", "MiejscaStartu")
                        .WithMany()
                        .HasForeignKey("MiejscaStartuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.Wycieczka", "Wycieczka")
                        .WithMany()
                        .HasForeignKey("WycieczkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiejscaStartu");

                    b.Navigation("Wycieczka");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowanePokoje", b =>
                {
                    b.HasOne("Travel_Hub.Models.Osrodki", "Osrodki")
                        .WithMany()
                        .HasForeignKey("OsrodkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.RodzajePokoi", "RodzajePokoi")
                        .WithMany()
                        .HasForeignKey("RodzajePokoiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osrodki");

                    b.Navigation("RodzajePokoi");
                });

            modelBuilder.Entity("Travel_Hub.Models.OferowaneWyzywienia", b =>
                {
                    b.HasOne("Travel_Hub.Models.OpcjeWyzywienia", "OpcjeWyzywienia")
                        .WithMany()
                        .HasForeignKey("OpcjeWyzywieniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.Osrodki", "Osrodki")
                        .WithMany()
                        .HasForeignKey("OsrodkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpcjeWyzywienia");

                    b.Navigation("Osrodki");
                });

            modelBuilder.Entity("Travel_Hub.Models.OfertaFirmy", b =>
                {
                    b.HasOne("Travel_Hub.Models.Firma", "Firma")
                        .WithMany()
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.Wycieczka", "Wycieczka")
                        .WithMany()
                        .HasForeignKey("WycieczkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Wycieczka");
                });

            modelBuilder.Entity("Travel_Hub.Models.Rezerwacja", b =>
                {
                    b.HasOne("Travel_Hub.Models.OferowaneMiejscaStartu", "OferowaneMiejscaStartu")
                        .WithMany()
                        .HasForeignKey("OferowaneMiejscaStartuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.WybranePokoje", "WybranePokoje")
                        .WithMany()
                        .HasForeignKey("WybranePokojeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.WybraneWyzywienia", "WybraneWyzywienia")
                        .WithMany()
                        .HasForeignKey("WybraneWyzywieniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.Wycieczka", "Wycieczka")
                        .WithMany()
                        .HasForeignKey("WycieczkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OferowaneMiejscaStartu");

                    b.Navigation("WybranePokoje");

                    b.Navigation("WybraneWyzywienia");

                    b.Navigation("Wycieczka");
                });

            modelBuilder.Entity("Travel_Hub.Models.WybranePokoje", b =>
                {
                    b.HasOne("Travel_Hub.Models.Osrodki", "Osrodki")
                        .WithMany()
                        .HasForeignKey("OsrodkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.RodzajePokoi", "RodzajePokoi")
                        .WithMany()
                        .HasForeignKey("RodzajePokoiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osrodki");

                    b.Navigation("RodzajePokoi");
                });

            modelBuilder.Entity("Travel_Hub.Models.WybraneWyzywienia", b =>
                {
                    b.HasOne("Travel_Hub.Models.OpcjeWyzywienia", "OpcjeWyzywienia")
                        .WithMany()
                        .HasForeignKey("OpcjeWyzywieniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Hub.Models.Osrodki", "Osrodki")
                        .WithMany()
                        .HasForeignKey("OsrodkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpcjeWyzywienia");

                    b.Navigation("Osrodki");
                });

            modelBuilder.Entity("Travel_Hub.Models.Wycieczka", b =>
                {
                    b.HasOne("Travel_Hub.Models.Osrodki", "Osrodki")
                        .WithMany()
                        .HasForeignKey("OsrodkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osrodki");
                });
#pragma warning restore 612, 618
        }
    }
}
