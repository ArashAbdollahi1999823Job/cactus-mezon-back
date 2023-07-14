using Domain.Entities.IdentityEntity;

namespace Application.IContracts.IRepository;

public interface IUserVerifyRepository
{
    public Task<bool> UserVerifyAdd(UserVerify userVerify);
    public Task<bool> UserVerifyDelete(string phoneNumber);
    public Task<UserVerify> UserVerifyGet(string phoneNumber);
}