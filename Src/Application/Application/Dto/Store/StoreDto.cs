using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.Store;
public class StoreDto:IMapFrom<Domain.Entities.StoreEntity.Store>
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; } 
    public string User { get; set; }
    public string UserId { get; set; }
    public string SellerPhoneNumber { get; set; }
    public string Slug { get; set; }
    
    
    #region MappingStoreDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.StoreEntity.Store, StoreDto>()
            .ForMember(x => x.User, c => c.MapFrom(v => v.User.UserName))
            .ForMember(x => x.UserId, c => c.MapFrom(v => v.User.Id))
            .ForMember(x => x.SellerPhoneNumber, c => c.MapFrom(v => v.User.PhoneNumber));
    } 
    #endregion
}