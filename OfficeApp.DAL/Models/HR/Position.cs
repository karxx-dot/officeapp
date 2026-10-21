using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.HR;

public class Position
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(300)]
    public string? Description { get; set; }

    public decimal MinSalary { get; set; }

    public decimal MaxSalary { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
