using DelabinService.Contracts;
using DelabinService.Contracts.Interfaces;
using DelabinService.Data;
using DelabinService.Models;
using Microsoft.EntityFrameworkCore;

namespace DelabinService.Repository
{
    public class DocDataRepository : RepositoryBase<DocData>, IDataRepository
    {
        public DocDataRepository(DelabinServiceContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<DocData> DataByDocument(Guid documentId)
        {
            return FindByCondition(a => a.Documentid.Equals(documentId)).ToList();
        }
    }
}
