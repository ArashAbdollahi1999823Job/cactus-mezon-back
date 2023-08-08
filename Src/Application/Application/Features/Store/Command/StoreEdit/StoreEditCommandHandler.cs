using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Store;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Store.Command.StoreEdit;
public class StoreEditCommandHandler:IRequestHandler<StoreEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public StoreEditCommandHandler(IStoreRepository storeRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _storeRepository = storeRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(StoreEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _storeRepository.StoreExistAsync(req.Id, cancellationToken);
        if (check)
        {
            
            #region GetLastStore
            var storeSearchDto = new StoreSearchDto(req.Id,1,1000,null
                ,null,null,ActiveType.NotImportant,null,SortType.Desc,null);
            var store =  _storeRepository.StoreGetAllAsync(storeSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            #endregion
            
            #region StoreEdit
            var shopEditDto = new StoreEditDto(req.Id, req.Name, req.Address, req.PhoneNumber, req.MobileNumber, req.Description, req.UserId,req.IsActive,req.Slug);
            var checkEdit= await _storeRepository.StoreEditAsync(shopEditDto,cancellationToken);
            if (!checkEdit) return false;
            #endregion
            
            #region EditSiteMap
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+"store/"+store.Slug,"delete",null,null);
            _siteMapService.UpdateSiteMap(domainUrl+"store/"+req.Slug,"add","daily","0.8");
            #endregion
        }
        return true;
    }
}