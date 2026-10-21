using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Inventory;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(OfficeDbContext context) : base(context)
    {
    }
}
