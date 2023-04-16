using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Domain.Entities.ProductEntity;

public class Color:BaseEntity.BaseEntity
{
    public string Name { get; set; }
    public string Value { get; set; }


    public Color(string name, string value, long productId)
    {
        Name = name;
        Value = value;
        ProductId = productId;
    }

    public Product Product { set; get; }
    public long ProductId { set; get; }
}