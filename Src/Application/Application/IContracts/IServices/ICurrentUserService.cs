namespace Application.IContracts.IServices;
public interface ICurrentUserService
{
    public string Id { get; }
    public string PhoneNumber { get; }
}