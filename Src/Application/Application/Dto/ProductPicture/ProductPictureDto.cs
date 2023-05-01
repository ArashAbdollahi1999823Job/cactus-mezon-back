using Application.Common.AutoMapping;
using AutoMapper;

namespace Application.Dto.ProductPicture;
public class ProductPictureDto:IMapFrom<Domain.Entities.PictureEntity.ProductPicture>
{
    public Guid Id { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    public bool IsActive { get; set; } 
    public string Product { get; set; }
    public Guid ProductId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.PictureEntity.ProductPicture,ProductPictureDto>()
            .ForMember(x => x.Product, c => c.MapFrom(v => v.Product.Name));
    }
}