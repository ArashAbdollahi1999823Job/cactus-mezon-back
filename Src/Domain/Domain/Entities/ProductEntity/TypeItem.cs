namespace Domain.Entities.ProductEntity;

public class TypeItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TypeId { get; set; }
    public Type Type { get; set; }

    public TypeItem( string name, Guid typeId)
    {
        Name = name;
        TypeId = typeId;
    }
}