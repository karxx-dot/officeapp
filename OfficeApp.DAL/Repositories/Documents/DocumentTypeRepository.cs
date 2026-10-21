using OfficeApp.DAL.Data;
using OfficeApp.DAL.Models.Documents;
using OfficeApp.DAL.Repositories.Base;

namespace OfficeApp.DAL.Repositories.Documents;

public class DocumentTypeRepository : BaseRepository<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(OfficeDbContext context) : base(context)
    {
    }
}
