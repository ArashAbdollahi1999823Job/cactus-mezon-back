using Application.Dto.Account;
using Application.Dto.Identity;
using MediatR;

namespace Application.Features.Account.Commands.UserCode;

public class UserCodeCommand:CodeDto,IRequest<UserAuthorizeDto>
{
    
}