using DelabinService.Models;

namespace DelabinService.Contracts.Interfaces
{
    public interface IDataRepository : IRepositoryBase<DocData>
    {
        IEnumerable<DocData> DataByDocument(Guid documentId);
    }
}
