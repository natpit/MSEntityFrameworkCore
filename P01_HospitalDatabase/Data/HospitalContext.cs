

using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Config;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext:DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PacientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(en =>
            {
                en.Property(e => e.FirstName)
                .IsUnicode(true);

                en.Property(e => e.LastName)
                .IsUnicode(true);

                en.Property(e => e.Address)
                .IsUnicode(true);

                en.Property(e => e.Email)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Visitation>(en =>
            {
                en.Property(e => e.Comments)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Diagnose>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode(true);

                en.Property(e => e.Comments)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Doctor>(en =>
            {
                en.Property(e => e.Name)
                .IsUnicode(true);

                en.Property(e => e.Specialty)
                .IsUnicode(true);
            });
        }
    }
}
