using Microsoft.EntityFrameworkCore;
using PatientLibrary;
namespace RepositoryPatient
{
    public class PatientDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CKS2-DESKTOP;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping
            modelBuilder.Entity<Patient>().ToTable("tblPatient");
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
