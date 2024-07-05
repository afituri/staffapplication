using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class Language
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string LanguageName { get; set; }

    public ICollection<StaffLanguage> StaffLanguages { get; set; }
  }
}
