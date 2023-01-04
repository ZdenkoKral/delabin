using DelabinService.Contracts.Interfaces;
using DelabinService.Data;

namespace DelabinService.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private DelabinServiceContext _repoContext;
        private IDocumentsRepository _documentsRepository;
        private IDataRepository _dataRepository;

        public IDocumentsRepository DocumentsRepository
        {
            get
            {
                if (_documentsRepository == null)
                {
                    _documentsRepository = new DocumentRepository(_repoContext);
                }
                return _documentsRepository;
            }
        }

        public IDataRepository DataRepository
        {
            get
            {
                if (_dataRepository == null)
                {
                    _dataRepository = new DocDataRepository(_repoContext);
                }
                return _dataRepository;
            }
        }

        public RepositoryWrapper(DelabinServiceContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
