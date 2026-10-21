using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;

namespace OfficeApp.DAL.Models.Documents;

public class Document
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required, MaxLength(400)]
    public string FilePath { get; set; } = null!;

    public DateTime UploadedAt { get; set; }

    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; } = null!;

    public int UploadedById { get; set; }
    public Employee UploadedBy { get; set; } = null!;

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
