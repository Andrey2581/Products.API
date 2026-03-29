namespace Product.Domain.SeedWorks;

public abstract class EntityId<T>
{
    public virtual T? Id { get; set; }

    public abstract bool IsUnassigned();

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}