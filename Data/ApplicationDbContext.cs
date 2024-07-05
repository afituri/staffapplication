using Microsoft.EntityFrameworkCore;
using StaffInformationApp.Models;

namespace StaffInformationApp.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Staff> Staff { get; set; }
    public DbSet<EducationLevel> EducationLevels { get; set; }
    public DbSet<DutyStation> DutyStations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<SoftwareExpertise> SoftwareExpertise { get; set; }
    // public DbSet<Language> Languages { get; set; }
    public DbSet<StaffSoftwareExpertise> StaffSoftwareExpertise { get; set; }
    // public DbSet<StaffLanguage> StaffLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Configure the relationships with Fluent API

      // Staff and EducationLevel relationship
      modelBuilder.Entity<Staff>()
          .HasOne(s => s.HighestLevelOfEducation)
          .WithMany(e => e.StaffMembers)
          .HasForeignKey(s => s.HighestLevelOfEducationId)
          .OnDelete(DeleteBehavior.NoAction);

      // Staff and DutyStation relationship
      modelBuilder.Entity<Staff>()
          .HasOne(s => s.DutyStation)
          .WithMany(d => d.StaffMembers)
          .HasForeignKey(s => s.DutyStationId)
          .OnDelete(DeleteBehavior.NoAction);

      // Project and Staff relationship
      modelBuilder.Entity<Project>()
          .HasOne(p => p.Staff)
          .WithMany(s => s.Projects)
          .HasForeignKey(p => p.StaffId)
          .OnDelete(DeleteBehavior.NoAction);

      // StaffSoftwareExpertise and Staff relationship
      modelBuilder.Entity<StaffSoftwareExpertise>()
          .HasOne(se => se.Staff)
          .WithMany(s => s.SoftwareExpertises)
          .HasForeignKey(se => se.StaffId)
          .OnDelete(DeleteBehavior.NoAction);

      // StaffSoftwareExpertise and SoftwareExpertise relationship
      modelBuilder.Entity<StaffSoftwareExpertise>()
          .HasOne(se => se.SoftwareExpertise)
          .WithMany(software => software.StaffSoftwareExpertises)
          .HasForeignKey(se => se.SoftwareExpertiseId)
          .OnDelete(DeleteBehavior.NoAction);

      // StaffLanguage and Staff relationship
      modelBuilder.Entity<StaffLanguage>()
          .HasOne(sl => sl.Staff)
          .WithMany(s => s.Languages)
          .HasForeignKey(sl => sl.StaffId)
          .OnDelete(DeleteBehavior.NoAction);

      // StaffLanguage and Language relationship
      modelBuilder.Entity<StaffLanguage>()
          .HasOne(sl => sl.Language)
          .WithMany(language => language.StaffLanguages)
          .HasForeignKey(sl => sl.LanguageId)
          .OnDelete(DeleteBehavior.NoAction);
    }
  }
}
