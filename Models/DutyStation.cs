using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffInformationApp.Models
{
  public class DutyStation
  {
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Location { get; set; }

    public ICollection<Staff> StaffMembers { get; set; }
  }
}
