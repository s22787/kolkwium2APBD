using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class KolosDbContext : DbContext
    {
        //public DbSet<> coś { get; set; }
        

        public KolosDbContext(DbContextOptions options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            


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
