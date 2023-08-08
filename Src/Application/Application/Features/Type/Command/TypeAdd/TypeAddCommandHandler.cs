using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Type;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Type.Command.TypeAdd;
public class TypeAddCommandHandler:IRequestHandler<TypeAddCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeRepository _typeRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public TypeAddCommandHandler(ITypeRepository typeRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _typeRepository = typeRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    
    public async Task<bool> Handle(TypeAddCommand req, CancellationToken cancellationToken)
    {
        #region TypeAdd
        var typeAddDto = new TypeAddDto(req.ParentTypeId,req.Name,req.Description,req.MetaDescription,req.Summary,req.Slug,req.Sort);
        var checkAdd= await _typeRepository.TypeAddAsync(typeAddDto,cancellationToken);
        #endregion
       
        if (checkAdd)
        {
            var typeSearchDto = new TypeSearchDto(1,1000,new Guid("00000000-0000-0000-0000-000000000000"),ActiveType.NotImportant,null
                ,new Guid("00000000-0000-0000-0000-000000000001"),SortType.Desc,req.Slug,new Guid("00000000-0000-0000-0000-000000000001"));
            var typeDto =  _typeRepository.TypeGetAllAsync(typeSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+typeDto.Slug,"add","daily","0.9");
        }

        return checkAdd;
    }
}