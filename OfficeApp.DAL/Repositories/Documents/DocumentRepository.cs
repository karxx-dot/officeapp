using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Documents;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Documents;

public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(OfficeDbContext context) : base(context)
    {
    }
}
