using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.HR;

public class Attendance
{
    [Key]
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    [MaxLength(300)]
    public string? Notes { get; set; }
}
