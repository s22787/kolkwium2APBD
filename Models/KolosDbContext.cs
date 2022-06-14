using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class KolosDbContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<MusicianTrack> MusicianTrack { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }


        public KolosDbContext(DbContextOptions options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Album>(e=> {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel);

                e.ToTable("Album");
            });

            modelBuilder.Entity<Musician>(e => {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).IsRequired().HasMaxLength(20);

                e.ToTable("Musician");
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired();

                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<Track>(e => {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                e.ToTable("Track");
            });

            modelBuilder.Entity<MusicianTrack>(e => {
                e.HasKey(e => new { e.IdMusician, e.IdTrack });
                e.HasOne(e => e.Musician).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdTrack);

                e.ToTable("MusicianTrack");
            });


            //var list=new List<Coś>={};
            //do nuggetowej konsolki -> Add-Migration "nazwa"
            //Update-Database

            /*modelBuilder.Entity<coś>(e=>
            {
                e.HasKey(e => e.ID).HasMaxLength(100).IsRequired();
                e.HasData(list);
                e.ToTable("tabelaCoś");

                e.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription).OnDelete(DeleteBehavior.ClientCascade);
            });*/

        }
    }
}
