#region UsingAndNamespace

using AutoMapper;

namespace Application.Common.AutoMapping;
#endregion

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

