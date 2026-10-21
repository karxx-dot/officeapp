using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.HR;

public class LeaveRequest
{
    [Key]
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Required, MaxLength(300)]
    public string Reason { get; set; } = null!;

    [Required, MaxLength(30)]
    public string Status { get; set; } = null!;
}
