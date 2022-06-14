using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolos2.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "Punk" },
                    { 2, "Rock" }
                });

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "Kowal" },
                    { 2, "Krzystof", "Nowak", "Seniore Java" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "APBD", 1, new DateTime(2022, 6, 14, 14, 43, 15, 582, DateTimeKind.Local).AddTicks(7032) });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 2, "PRI", 2, new DateTime(2022, 6, 14, 14, 43, 15, 584, DateTimeKind.Local).AddTicks(5535) });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 10.23f, 1, "kolos z APBD" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 2, 8.01f, 2, "Java 8.0" });

            migrationBuilder.InsertData(
                table: "MusicianTrack",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MusicianTrack",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MusicianTrack",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MusicianTrack",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 2);
        }
    }
}
