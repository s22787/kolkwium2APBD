﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolos2.Models;

namespace kolos2.Migrations
{
    [DbContext(typeof(KolosDbContext))]
    partial class KolosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolos2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "APBD",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 14, 14, 43, 15, 582, DateTimeKind.Local).AddTicks(7032)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "PRI",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 6, 14, 14, 43, 15, 584, DateTimeKind.Local).AddTicks(5535)
                        });
                });

            modelBuilder.Entity("kolos2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Punk"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Rock"
                        });
                });

            modelBuilder.Entity("kolos2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Nickname = "Kowal"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Krzystof",
                            LastName = "Nowak",
                            Nickname = "Seniore Java"
                        });
                });

            modelBuilder.Entity("kolos2.Models.MusicianTrack", b =>
                {
                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusician", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("MusicianTrack");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("kolos2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 10.23f,
                            IdMusicAlbum = 1,
                            TrackName = "kolos z APBD"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 8.01f,
                            IdMusicAlbum = 2,
                            TrackName = "Java 8.0"
                        });
                });

            modelBuilder.Entity("kolos2.Models.Album", b =>
                {
                    b.HasOne("kolos2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Album")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("kolos2.Models.MusicianTrack", b =>
                {
                    b.HasOne("kolos2.Models.Musician", "Musician")
                        .WithMany("MusicianTrack")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kolos2.Models.Track", "Track")
                        .WithMany("MusicianTrack")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolos2.Models.Track", b =>
                {
                    b.HasOne("kolos2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolos2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("kolos2.Models.MusicLabel", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolos2.Models.Musician", b =>
                {
                    b.Navigation("MusicianTrack");
                });

            modelBuilder.Entity("kolos2.Models.Track", b =>
                {
                    b.Navigation("MusicianTrack");
                });
#pragma warning restore 612, 618
        }
    }
}
