using Application.Dto.Type;
using Application.IContracts.IRepository;
using MediatR;
namespace Application.Features.Type.Command.TypeAdd;
public class TypeAddCommandHandler:IRequestHandler<TypeAddCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeRepository _typeRepository;
    public TypeAddCommandHandler(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    #endregion
    
    public async Task<bool> Handle(TypeAddCommand req, CancellationToken cancellationToken)
    {
        var typeAddDto = new TypeAddDto(req.ParentTypeId,req.Name,req.Description,req.MetaDescription,req.Summary,req.Slug);
        return await _typeRepository.TypeAddAsync(typeAddDto,cancellationToken);
    }
}