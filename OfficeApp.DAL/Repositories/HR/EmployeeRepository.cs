using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.HR;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(OfficeDbContext context) : base(context)
    {
    }
}
