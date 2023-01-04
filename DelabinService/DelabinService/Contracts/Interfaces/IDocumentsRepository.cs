using DelabinService.Models;

namespace DelabinService.Contracts.Interfaces
{
    public interface IDocumentsRepository : IRepositoryBase<Document>
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentWithDetails(Guid documentId);
        void CreateDocument(Document document);
        void UpdateDocument(Document document);
        void DeleteDocument(Document document);
    }
}
