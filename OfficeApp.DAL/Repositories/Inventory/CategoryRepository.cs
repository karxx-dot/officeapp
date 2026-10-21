using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Inventory;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(OfficeDbContext context) : base(context)
    {
    }
}
