using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.HR;

public class LeaveRequestRepository : BaseRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(OfficeDbContext context) : base(context)
    {
    }
}
