using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV_Manager.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CV_Manager.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Define DbSets for your entities
        public DbSet<CV> CVs { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ExperienceInformation> ExperienceInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CV>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            // CV -> PersonalInformation
            modelBuilder.Entity<CV>()
                .HasOne(cv => cv.PersonalInformation)
                .WithOne(pi => pi.CV)
                .HasForeignKey<CV>(cv => cv.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(256);
                entity.Property(e => e.MobileNumber).IsRequired();
            });

            modelBuilder.Entity<ExperienceInformation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CompanyName)
                      .IsRequired()
                      .HasMaxLength(20);
            });

            modelBuilder.Entity<CV>()
                .HasOne(cv => cv.ExperienceInformation)
                .WithOne(ei => ei.CV)
                .HasForeignKey<CV>(cv => cv.ExperienceInformationId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
