using Application.Dto.Off;
using MediatR;
namespace Application.Features.Off.Command.OffEdit;
public class OffEditCommand:OffEditDto,IRequest<bool>
{
    
}