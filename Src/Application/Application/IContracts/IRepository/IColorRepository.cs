using Application.Dto.Color;
using Domain.Entities.ProductEntity;

namespace Application.IContracts.IRepository;
public interface IColorRepository
{
    public Task<bool> ColorAddAsync(ColorAddDto colorAddDto,CancellationToken cancellationToken);
    public Task<List<ColorDto>> ColorGetAllAsync(ColorSearchDto colorSearchDto, CancellationToken cancellationToken);
    public Task<Color> ColorGetByIdAsync(long id, CancellationToken cancellationToken);
    public Task<bool> ColorExistAsync(long id,CancellationToken cancellationToken);
    public Task<bool> ColorDeleteAsync(long id, CancellationToken cancellationToken);
}