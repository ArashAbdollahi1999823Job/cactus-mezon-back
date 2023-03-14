#region UsingAndNamespace
namespace Application.IContracts.IServices;
#endregion
public interface ICurrentUserService
{
    public string Id { get; }
    public string PhoneNumber { get; }
}