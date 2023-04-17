using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.TypeItem.Command.TypeItemDelete;
public class TypeItemCommandHandler:IRequestHandler<TypeItemDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeItemRepository _typeItemRepository;
    public TypeItemCommandHandler(ITypeItemRepository typeItemRepository)
    {
        _typeItemRepository = typeItemRepository;
    }
    #endregion
    public async Task<bool> Handle(TypeItemDeleteCommand req, CancellationToken cancellationToken)
    {
        var typeItem =await _typeItemRepository.TypeItemExistAsync(req.Id, cancellationToken);

        if (typeItem)
        {
           return await _typeItemRepository.TypeItemDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.TypeItemFailedDeleteOnHandle);
    }
}