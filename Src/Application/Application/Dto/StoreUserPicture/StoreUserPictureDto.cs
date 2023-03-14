using Application.Common.AutoMapping;
using Application.Dto.TypePicture;
using AutoMapper;
using Domain.Entities.PictureEntity;

namespace Application.Dto.StoreUserPicture;
public class StoreUserPictureDto:IMapFrom<StorePicture>
{
    public long Id { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    public bool IsActive { get; set; }


    #region MappingTypePictureDto
    public void Mapping(Profile profile)
    {
        profile.CreateMap<StorePicture, StoreUserPictureDto>();
    } 
    #endregion
}