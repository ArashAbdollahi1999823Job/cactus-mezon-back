using Application.Dto.Base;
using Application.Dto.User;

namespace Application.IContracts.IRepository;

public interface IUserRepository
{
    public Task<bool> ExistUserByPhoneNumberAsync(string phoneNumber,CancellationToken cancellationToken);
    public Task<PaginationDto<UserDto>> UserGetAllAsync(UserSearchDto userSearchDto,CancellationToken cancellationToken);

    public Task<bool> UserDeleteAsync(string id, CancellationToken cancellationToken);
}