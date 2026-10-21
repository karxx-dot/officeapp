using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Operations;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Title { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public DateTime DueDate { get; set; }

    [Required, MaxLength(20)]
    public string Priority { get; set; } = null!;

    [Required, MaxLength(30)]
    public string Status { get; set; } = null!;

    public int AssignedToId { get; set; }
    public Employee AssignedTo { get; set; } = null!;
}
