using Application.Common.Messages;
using Application.Dto.Type;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Type.Command.TypeEdit;
public class TypeEditCommandHandler:IRequestHandler<TypeEditCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeRepository _typeRepository;
    public TypeEditCommandHandler(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    #endregion
    public async Task<bool> Handle(TypeEditCommand req, CancellationToken cancellationToken)
    {
        var check = await _typeRepository.TypeExistAsync(req.Id, cancellationToken);
        if (check)
        {
            var typeEditDto = new TypeEditDto(req.Id, req.ParentTypeId, req.Name, req.Description, req.MetaDescription, req.Summary, req.IsActive, req.IsDelete,req.Slug);
            return await _typeRepository.TypeEditAsync(typeEditDto, cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.TypeFailedEditOnHandle);
    }
}