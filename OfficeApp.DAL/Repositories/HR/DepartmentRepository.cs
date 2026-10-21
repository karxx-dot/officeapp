using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.HR;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(OfficeDbContext context) : base(context)
    {
    }
}
