namespace DelabinService.Contracts.Interfaces
{
    public interface IRepositoryWrapper
    {
        IDocumentsRepository DocumentsRepository { get; }
        IDataRepository DataRepository { get; } 
        Task SaveAsync();
    }
}
