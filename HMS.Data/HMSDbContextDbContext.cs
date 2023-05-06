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
            modelBuilder.Entity<patient>()
                .HasMany(x => x.schidules)
                .WithMany(x => x.patients)
                .UsingEntity<patientSchdule>(
                    x => x.HasOne(x => x.Schidule).WithMany(x => x.patientSchdules).HasForeignKey(x => x.schiduleId),
                    x => x.HasOne(x => x.patient).WithMany(x => x.patientSchdules).HasForeignKey(x => x.patientId),
                    x => x.HasKey(x => new { x.patientId, x.schiduleId })
                );
            modelBuilder.Entity<patient>()
                .HasMany(x => x.treatments)
                .WithMany(x => x.patient)
                .UsingEntity<patientTreatment>(
                    x => x.HasOne(x => x.Treatment).WithMany(x => x.patientTreatment).HasForeignKey(x => x.treatmentId),
                    x => x.HasOne(x => x.patient).WithMany(x => x.patientTreatment).HasForeignKey(x => x.patientId),
                    x => x.HasKey(x => new { x.patientId, x.treatmentId })
                );
            modelBuilder.Entity<nurse>()
                .HasMany(x => x.schidules)
                .WithMany(x => x.nurses)
                .UsingEntity<nurseSchidule>(
                    x => x.HasOne(x => x.Schidule).WithMany(x => x.nurseSchidules).HasForeignKey(x => x.schiduleId),
                    x => x.HasOne(x => x.nurse).WithMany(x => x.nurseSchidules).HasForeignKey(x => x.nurseId),
                    x => x.HasKey(x => new { x.schiduleId, x.nurseId })
                );

            modelBuilder.Entity<doctor>()
                .HasMany(x => x.schidules)
                .WithMany(x => x.doctors)
                .UsingEntity<doctorSchidule>(
                    x => x.HasOne(x => x.Schidule).WithMany(x => x.doctorSchidule).HasForeignKey(x => x.schiduleId),
                    x => x.HasOne(x => x.doctor).WithMany(x => x.doctorSchidules).HasForeignKey(x => x.doctortId),
                    x => x.HasKey(x => new { x.schiduleId, x.doctortId })
                );
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.doctor)
            //    .WithOne(d => d.user)
            //    .HasForeignKey<doctor>(d => d.userId);
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.nurse)
            //    .WithOne(n => n.user)
            //    .HasForeignKey<nurse>(n => n.userId);
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.patient)
            //    .WithOne(p => p.user)
            //    .HasForeignKey<patient>(p => p.userId);

        }

        public DbSet<patient> patients { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<schidule> schidules { get; set; }
        public DbSet<treatment> treatments { get; set; }
        public DbSet<patientSchdule> patientSchdules { get; set; }
        public DbSet<patientTreatment> patientTreatments { get; set; }
        public DbSet<nurse> nurses { get; set; }
        public DbSet<nurseSchidule> nurseSchidules { get; set; }
        public DbSet<doctor> doctors { get; set; }
        public DbSet<doctorSchidule> doctorSchidules { get; set; }
    }
}