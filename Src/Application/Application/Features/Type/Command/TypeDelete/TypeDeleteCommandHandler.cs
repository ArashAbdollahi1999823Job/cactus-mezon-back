using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Type.Command.TypeDelete;
public class TypeDeleteCommandHandler:IRequestHandler<TypeDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeRepository _typeRepository;
    public TypeDeleteCommandHandler(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    #endregion
    public async Task<bool> Handle(TypeDeleteCommand req, CancellationToken cancellationToken)
    {
        var check = await _typeRepository.TypeExistAsync(req.Id, cancellationToken);
        if(check) return await _typeRepository.TypeDeleteAsync(req.Id, cancellationToken);
        throw new BadRequestEntityException(ApplicationMessages.TypeFailedDeleteOnHandle);
    }
}