#region UsingAndNamespace

namespace Domain.Entities.BaseEntity.Command;
#endregion
public interface ICommands
{
    public string Description { get; set; }
    public string Summary { get; set; }
    public bool IsActive { get; set; }
}

