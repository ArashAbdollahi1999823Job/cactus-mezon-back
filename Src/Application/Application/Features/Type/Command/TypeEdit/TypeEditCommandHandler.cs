using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Type;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Type.Command.TypeEdit;
public class TypeEditCommandHandler:IRequestHandler<TypeEditCommand,bool>
{
    #region CtorAndInjection
    private readonly ITypeRepository _typeRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public TypeEditCommandHandler(ITypeRepository typeRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _typeRepository = typeRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(TypeEditCommand req, CancellationToken cancellationToken)
    {
        var check = await _typeRepository.TypeExistAsync(req.Id, cancellationToken);
        if (check)
        {
            
            #region GetLastType
            var typeSearchDto = new TypeSearchDto(1,1000,req.Id,ActiveType.NotImportant,null,new Guid("00000000-0000-0000-0000-000000000001")
                ,SortType.Desc,null,new Guid("00000000-0000-0000-0000-000000000001"));
            var type =  _typeRepository.TypeGetAllAsync(typeSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            #endregion

            #region TypeEdit
            var typeEditDto = new TypeEditDto(req.Id, req.ParentTypeId, req.Name, req.Description, req.MetaDescription, req.Summary, req.IsActive, req.IsDelete,req.Slug,req.Sort);
            var checkEdit=await _typeRepository.TypeEditAsync(typeEditDto, cancellationToken);
            if (!checkEdit) return false;
            #endregion
            
            #region EditSiteMap
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+type.Slug,"delete",null,null);
            _siteMapService.UpdateSiteMap(domainUrl+req.Slug,"add","daily","0.9");
            #endregion
        }
        return true;
    }
}