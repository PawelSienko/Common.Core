namespace Common.Core.Repository
{
    public interface IRepositoryBase<in TId, TItem> : IUnitOfWork
    {
        void Add(TItem item);
        
        void Delete(TItem item);

        TItem Select(TId id);
    }
}
