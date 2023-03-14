#region UsingAndNamespace
using Application.Dto.Store;
using MediatR;
namespace Application.Features.Store.Command.StoreAdd;
#endregion
public class StoreAddCommand:StoreAddDto,IRequest<bool>
{
}