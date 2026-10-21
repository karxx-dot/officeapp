using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.HR;

public class PositionRepository : BaseRepository<Position>, IPositionRepository
{
    public PositionRepository(OfficeDbContext context) : base(context)
    {
    }
}
