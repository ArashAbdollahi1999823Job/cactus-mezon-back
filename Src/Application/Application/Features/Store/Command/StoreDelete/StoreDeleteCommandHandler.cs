using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Store;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;
namespace Application.Features.Store.Command.StoreDelete;
public class StoreDeleteCommandHandler:IRequestHandler<StoreDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public StoreDeleteCommandHandler(IStoreRepository storeRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _storeRepository = storeRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(StoreDeleteCommand req, CancellationToken cancellationToken)
    {
      var check= await _storeRepository.StoreExistAsync(req.Id,cancellationToken);
      if (check)
      {
          #region GetLastStore
          var storeSearchDto = new StoreSearchDto(new Guid("00000000-0000-0000-0000-000000000000"),1,1000,null
              ,null,null,ActiveType.NotImportant,null,SortType.Desc,null);
          var store =  _storeRepository.StoreGetAllAsync(storeSearchDto, cancellationToken).Result.Data.FirstOrDefault();
          #endregion
          
          #region StoreDelete
          var checkDelete= await _storeRepository.StoreDeleteAsync(req.Id,cancellationToken);
          if (!checkDelete) return false;
          #endregion
          
          #region SiteMapDelete
          var domainUrl = _configuration["Url:BackendUrl:Production"];
          _siteMapService.UpdateSiteMap(domainUrl+"store/"+store.Slug,"delete",null,null);
          #endregion
      }
      return true;
    }
}