using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class StaffSoftwareExpertise
  {
    public int Id { get; set; }

    [Required]
    public int SoftwareExpertiseId { get; set; }
    public SoftwareExpertise SoftwareExpertise { get; set; }

    [Required]
    [StringLength(100)]
    public string ExpertiseLevel { get; set; }

    public int StaffId { get; set; }
    public Staff Staff { get; set; }
  }
}
