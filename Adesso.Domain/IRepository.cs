namespace Adesso.Domain;

public interface IRepository<T> where T : IAggregateRoot
{
    Task AddAsync(T entity);
}