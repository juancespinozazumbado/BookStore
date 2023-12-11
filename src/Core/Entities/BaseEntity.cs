
namespace BookStore.Core.Entities;

public abstract class BaseEntity
{
    protected Guid Id { get; private set; }
    protected DateTime DateTimeCreated { get; private set; }
    protected DateTime DateTimeEdited { get; private set; }
    protected DateTime DateTimeDelete { get; private set; }
}