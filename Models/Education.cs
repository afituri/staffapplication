using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class EducationLevel
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Level { get; set; }

    public ICollection<Staff> StaffMembers { get; set; }
  }
}
