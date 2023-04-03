namespace Domain.Entities.BaseEntity;
public abstract class BaseEntity
{
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
}

