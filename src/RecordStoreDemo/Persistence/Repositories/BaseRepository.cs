namespace RecordStoreDemo.Persistence.Repositories;

public class BaseRepository<TEntity>(RecordStoreDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    internal DbSet<TEntity> dbSet = context.Set<TEntity>();

    public virtual async Task Add(TEntity newEntity)
    {
        dbSet.Add(newEntity);
        await context.SaveChangesAsync();
    }

    public virtual async Task Delete(Guid id)
    {
        TEntity entityToDelete = dbSet.Find(id) ?? throw new EntityNotFoundException(id);
        dbSet.Remove(entityToDelete);
        await context.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entityToUpdate)
    {
        dbSet.Update(entityToUpdate);
        await context.SaveChangesAsync();
    }
}