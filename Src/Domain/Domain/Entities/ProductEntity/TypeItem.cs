namespace Domain.Entities.ProductEntity;

public class TypeItem
{
    public long Id { get; set; }
    public string Name { get; set; }

    public long TypeId { get; set; }
    public Type Type { get; set; }

    public TypeItem( string name, long typeId)
    {
        Name = name;
        TypeId = typeId;
    }
}