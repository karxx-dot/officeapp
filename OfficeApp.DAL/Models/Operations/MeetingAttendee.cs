using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Operations;

public class MeetingAttendee
{
    [Key]
    public int Id { get; set; }

    public int MeetingId { get; set; }
    public Meeting Meeting { get; set; } = null!;

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public bool Confirmed { get; set; }
}
