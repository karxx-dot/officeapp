using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.HR;

public class AttendanceRepository : BaseRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(OfficeDbContext context) : base(context)
    {
    }
}
