using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.HR;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(80)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(80)]
    public string LastName { get; set; } = null!;

    [Required, MaxLength(150)]
    public string Email { get; set; } = null!;

    [MaxLength(30)]
    public string? Phone { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public bool IsActive { get; set; } = true;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    public int PositionId { get; set; }
    public Position Position { get; set; } = null!;

    public int? ManagerId { get; set; }
    public Employee? Manager { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    public ICollection<MeetingAttendee> MeetingAttendees { get; set; } = new List<MeetingAttendee>();
    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    public ICollection<Document> Documents { get; set; } = new List<Document>();
}
