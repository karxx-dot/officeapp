using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Inventory;

public class AssetAssignment
{
    [Key]
    public int Id { get; set; }

    public int AssetId { get; set; }
    public Asset Asset { get; set; } = null!;

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime AssignedDate { get; set; }

    public DateTime? ReturnedDate { get; set; }
}
