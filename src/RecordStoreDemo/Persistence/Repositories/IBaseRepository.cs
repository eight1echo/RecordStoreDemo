namespace RecordStoreDemo.Persistence.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task Add(TEntity newEntity);
    Task Delete(Guid id);
    Task Update(TEntity entityToUpdate);
}