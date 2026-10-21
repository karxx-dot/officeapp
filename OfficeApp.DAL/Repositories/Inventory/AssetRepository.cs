using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Inventory;

public class AssetRepository : BaseRepository<Asset>, IAssetRepository
{
    public AssetRepository(OfficeDbContext context) : base(context)
    {
    }
}
