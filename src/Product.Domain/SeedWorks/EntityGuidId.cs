namespace Product.Domain.SeedWorks;

public class EntityGuidId : EntityId<Guid>
{
    public override bool IsUnassigned()
    {
        return Id == Guid.Empty;
    }
}