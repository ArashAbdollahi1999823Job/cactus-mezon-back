namespace Domain.Entities.BaseEntity;

public class BaseAuditableEntity:BaseEntity
{
    public long? CreatedBy { get; set; }
    public long? LastModifiedBy { get; set; }
}

