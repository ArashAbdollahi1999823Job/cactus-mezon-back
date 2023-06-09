using Application.Dto.Identity;
using MediatR;

namespace Application.Features.Account.Commands.UserForget;

public class UserForgetCommand:ForgetDto,IRequest<bool>
{
    
}