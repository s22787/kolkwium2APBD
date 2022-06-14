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
            var AlbumList = new List<Album>
            {
                new Album
                {
                    IdAlbum=1,
                    AlbumName="APBD",
                    PublishDate=DateTime.Now,
                    IdMusicLabel=1
                },
                new Album
                {
                    IdAlbum=2,
                    AlbumName="PRI",
                    PublishDate=DateTime.Now,
                    IdMusicLabel=2
                }
            };

            var MusicLabelList = new List<MusicLabel>
            {
                new MusicLabel
                {
                    IdMusicLabel=1,
                    Name="Punk"
                },
                new MusicLabel
                {
                    IdMusicLabel=2,
                    Name="Rock"
                },
            };

            var MusicianList = new List<Musician>
            {
                new Musician
                {
                    IdMusician=1,
                    FirstName="Jan",
                    LastName="Kowalski",
                    Nickname="Kowal"
                },
                new Musician
                {
                    IdMusician=2,
                    FirstName="Krzystof",
                    LastName="Nowak",
                    Nickname="Seniore Java"
                }
            };

            var TrackList = new List<Track>
            {
                new Track
                {
                    IdTrack=1,
                    TrackName="kolos z APBD",
                    Duration=10.23f,
                    IdMusicAlbum=1
                },
                new Track
                {
                    IdTrack=2,
                    TrackName="Java 8.0",
                    Duration=8.01f,
                    IdMusicAlbum=2
                }
            };

            var MusicianTrackList = new List<MusicianTrack>
            {
                new MusicianTrack
                {
                    IdMusician=1,
                    IdTrack=1
                },
                new MusicianTrack
                {
                    IdMusician=2,
                    IdTrack=2
                }
            };




            modelBuilder.Entity<Album>(e=> {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel);

                e.HasData(AlbumList);
                e.ToTable("Album");
            });

            modelBuilder.Entity<Musician>(e => {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).IsRequired().HasMaxLength(20);

                e.HasData(MusicianList);
                e.ToTable("Musician");
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired();

                e.HasData(MusicLabelList);
                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<Track>(e => {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(TrackList);
                e.ToTable("Track");
            });

            modelBuilder.Entity<MusicianTrack>(e => {
                e.HasKey(e => new { e.IdMusician, e.IdTrack });
                e.HasOne(e => e.Musician).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdTrack);

                e.HasData(MusicianTrackList);
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
