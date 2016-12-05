namespace Common.Core.Repository
{
    public abstract class RepositoryBase<TId,TItem> : IRepositoryBase<TId,TItem>
    {
        public abstract void Add(TItem item);
        
        public abstract void Delete(TItem item);

        public abstract TItem Select(TId id);

        public abstract void Commit();
    }
}
