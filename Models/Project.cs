using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class Project
  {
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string ProjectTitleAndLocation { get; set; }

    [Required]
    [StringLength(100)]
    public string LevelOfResponsibility { get; set; }

    [StringLength(500)]
    public string BriefDescriptionOfRole { get; set; }

    public int StaffId { get; set; }
    public Staff Staff { get; set; }
  }
}
