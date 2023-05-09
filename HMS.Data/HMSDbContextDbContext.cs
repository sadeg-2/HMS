using HMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HMS.Data
{
    public class HMSDbContext : IdentityDbContext<User>
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Schidules)
                .WithMany(x => x.Patients)
                .UsingEntity<PatientSchdule>(
                    x => x.HasOne(x => x.Schidule).WithMany(x => x.PatientSchdules).HasForeignKey(x => x.SchiduleId),
                    x => x.HasOne(x => x.Patient).WithMany(x => x.PatientSchdules).HasForeignKey(x => x.PatientId),
                    x => x.HasKey(x => new { x.PatientId, x.SchiduleId })
                );
            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Treatments)
                .WithMany(x => x.Patient)
                .UsingEntity<PatientTreatment>(
                    x => x.HasOne(x => x.Treatment).WithMany(x => x.PatientTreatment).HasForeignKey(x => x.TreatmentId),
                    x => x.HasOne(x => x.Patient).WithMany(x => x.PatientTreatment).HasForeignKey(x => x.PatientId),
                    x => x.HasKey(x => new { x.PatientId, x.TreatmentId })
                );
           
            
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.doctor)
            //    .WithOne(d => d.user)
            //    .HasForeignKey<doctor>(d => d.userId);
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Nurse)
            //    .WithOne(n => n.user)
            //    .HasForeignKey<Nurse>(n => n.userId);
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Patient)
            //    .WithOne(p => p.user)
            //    .HasForeignKey<Patient>(p => p.userId);

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schidule> Schidules { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PatientSchdule> PatientSchdules { get; set; }
        public DbSet<PatientTreatment> PatientTreatments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}