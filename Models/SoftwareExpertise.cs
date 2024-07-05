using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class SoftwareExpertise
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string SoftwareName { get; set; }

    public ICollection<StaffSoftwareExpertise> StaffSoftwareExpertises { get; set; }
  }
}
