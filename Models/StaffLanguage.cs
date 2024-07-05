using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class StaffLanguage
  {
    public int Id { get; set; }

    [Required]
    public int LanguageId { get; set; }
    public Language Language { get; set; }

    [Required]
    [StringLength(100)]
    public string LevelOfResponsibility { get; set; }

    public int StaffId { get; set; }
    public Staff Staff { get; set; }
  }
}
