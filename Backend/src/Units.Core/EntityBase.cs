namespace Units.Core;

public abstract class EntityBase<T>
{
    public T Id { get; set; } = default!;
}
