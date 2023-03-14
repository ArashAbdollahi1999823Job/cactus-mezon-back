using Application.Dto.Store;
using MediatR;
namespace Application.Features.Store.Command.StoreEdit;
public class StoreEditCommand:StoreEditDto,IRequest<bool>
{
}