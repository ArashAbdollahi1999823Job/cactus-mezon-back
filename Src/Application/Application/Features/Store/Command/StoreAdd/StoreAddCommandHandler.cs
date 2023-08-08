using Application.Common.Enums;
using Application.Common.Helpers;
using Application.Dto.Store;
using Application.Enums;
using Application.IContracts.IRepository;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Store.Command.StoreAdd;
public class StoreAddCommandHandler:IRequestHandler<StoreAddCommand,bool>
{
    #region CtorAndInjection
    private readonly IStoreRepository _storeRepository;
    private readonly ISiteMapService _siteMapService;
    private readonly IConfiguration _configuration;
    public StoreAddCommandHandler(IStoreRepository storeRepository, ISiteMapService siteMapService, IConfiguration configuration)
    {
        _storeRepository = storeRepository;
        _siteMapService = siteMapService;
        _configuration = configuration;
    }
    #endregion
    public async Task<bool> Handle(StoreAddCommand req, CancellationToken cancellationToken)
    {
        #region StoreAdd
        var storeAddDto = new StoreAddDto(req.Name, req.Address, req.PhoneNumber, req.MobileNumber, req.Description, req.UserId,req.Slug);
        var checkAdd=await _storeRepository.StoreAddAsync(storeAddDto,cancellationToken);
        #endregion
        
        if (checkAdd)
        {
            var storeSearchDto = new StoreSearchDto(new Guid("00000000-0000-0000-0000-000000000000"),1,1000,null
                ,null,null,ActiveType.NotImportant,null,SortType.Desc,req.Slug);
            var store =  _storeRepository.StoreGetAllAsync(storeSearchDto, cancellationToken).Result.Data.FirstOrDefault();
            var domainUrl = _configuration["Url:BackendUrl:Production"];
            _siteMapService.UpdateSiteMap(domainUrl+"store/"+store.Slug,"add","daily","0.8");
        }

        return checkAdd;
    }
}