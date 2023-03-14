#region UsingAndNamespace
namespace Domain.Entities.BaseEntity.Command;
#endregion

public class Commands:ICommands
{
    public string Description { get; set; }
    public string Summary { get; set; }
    public bool IsActive { get; set; }
}
