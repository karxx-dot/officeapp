using System.ComponentModel.DataAnnotations;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Models.Inventory;

public class Asset
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(40)]
    public string Code { get; set; } = null!;

    [Required, MaxLength(150)]
    public string Name { get; set; } = null!;

    [MaxLength(300)]
    public string? Description { get; set; }

    public DateTime PurchaseDate { get; set; }

    public decimal PurchaseCost { get; set; }

    [Required, MaxLength(30)]
    public string Status { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public ICollection<AssetAssignment> AssetAssignments { get; set; } = new List<AssetAssignment>();
}
