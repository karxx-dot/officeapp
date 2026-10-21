using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Operations;

public class Meeting
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Title { get; set; } = null!;

    [MaxLength(400)]
    public string? Description { get; set; }

    public DateTime ScheduledAt { get; set; }

    public int DurationMinutes { get; set; }

    public int? RoomId { get; set; }
    public Room? Room { get; set; }

    public int OrganizerId { get; set; }
    public Employee Organizer { get; set; } = null!;

    public ICollection<MeetingAttendee> MeetingAttendees { get; set; } = new List<MeetingAttendee>();
}
