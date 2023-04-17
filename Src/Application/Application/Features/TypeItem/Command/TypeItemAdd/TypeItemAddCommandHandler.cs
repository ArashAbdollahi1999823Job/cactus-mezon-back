using Application.Common.Messages;
using Application.Dto.TypeItem;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.TypeItem.Command.TypeItemAdd;
public class TypeItemAddCommandHandler : IRequestHandler<TypeItemAddCommand, bool>
{
    #region CtorAndInjection
    private readonly ITypeItemRepository _typeItemRepository;
    public TypeItemAddCommandHandler(ITypeItemRepository typeItemRepository)
    {
        _typeItemRepository = typeItemRepository;
    }
    #endregion


    public async Task<bool> Handle(TypeItemAddCommand req, CancellationToken cancellationToken)
    {
  
            TypeItemAddDto typeItemAddDto = new TypeItemAddDto(req.Name,req.TypeId);
            return await _typeItemRepository.TypeItemAddAsync(typeItemAddDto,cancellationToken);
            throw new BadRequestEntityException(ApplicationMessages.TypeItemFailedAddOnHandle);
    }
}