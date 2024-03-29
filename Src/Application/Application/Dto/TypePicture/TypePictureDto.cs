﻿using Application.Common.AutoMapping;
using AutoMapper;
namespace Application.Dto.TypePicture;
public class TypePictureDto:IMapFrom<Domain.Entities.PictureEntity.TypePicture>
{
    public Guid Id { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    public bool IsActive { get; set; } 
    public string Type { get; set; }
    public Guid TypeId { get; set; }
    

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.PictureEntity.TypePicture,TypePictureDto>()
            .ForMember(x => x.Type, c => c.MapFrom(v => v.Type.Name));
    }
}