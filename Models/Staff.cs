using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class Staff
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string IndexNumber { get; set; }

    [Required]
    [StringLength(200)]
    public string FullNames { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(200)]
    public string CurrentLocation { get; set; }

    [Required]
    public int HighestLevelOfEducationId { get; set; }
    public EducationLevel HighestLevelOfEducation { get; set; }

    [Required]
    public int DutyStationId { get; set; }
    public DutyStation DutyStation { get; set; }

    public bool AvailabilityForRemoteWork { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<StaffSoftwareExpertise> SoftwareExpertises { get; set; } = new List<StaffSoftwareExpertise>();
    public ICollection<StaffLanguage> Languages { get; set; } = new List<StaffLanguage>();
  }
}
