using DelabinService.Contracts;
using DelabinService.Contracts.Interfaces;
using DelabinService.Data;
using DelabinService.Models;
using Microsoft.EntityFrameworkCore;

namespace DelabinService.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentsRepository
    {
        public DocumentRepository(DelabinServiceContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await FindAll()
                .OrderBy(ow => ow.id).Include(ac => ac.data)
                .ToListAsync();
        }

        public async Task<Document> GetDocumentWithDetails(Guid documentId)
        {
            return await FindByCondition(doc => doc.id.Equals(documentId))
                .Include(ac => ac.data)
                .FirstOrDefaultAsync();
        }

        public void CreateDocument(Document document)
        {
            Create(document);
        }

        public void UpdateDocument(Document document)
        {
            Update(document);
        }

        public void DeleteDocument(Document document)
        {
            Delete(document);
        }
    }
}
