#region UseingAndNamespace

using Domain.Entities.IdentityEntity;

namespace Application.IContracts.IServices;
#endregion
public interface ITokenService
{
   Task<string> CreateToken(User user);
}