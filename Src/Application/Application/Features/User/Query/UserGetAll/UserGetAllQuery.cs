using Application.Dto.Base;
using Application.Dto.User;
using MediatR;
namespace Application.Features.User.Query.UserGetAll;
public class UserGetAllQuery:UserSearchDto,IRequest<PaginationDto<UserDto>>
{

}   