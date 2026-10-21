using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Inventory;

public class AssetAssignmentRepository : BaseRepository<AssetAssignment>, IAssetAssignmentRepository
{
    public AssetAssignmentRepository(OfficeDbContext context) : base(context)
    {
    }
}
