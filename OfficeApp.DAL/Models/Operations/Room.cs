using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Operations;

public class Room
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    [MaxLength(150)]
    public string? Location { get; set; }

    public bool IsAvailable { get; set; } = true;

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
