using Application.Dto.Color;

namespace Application.IContracts.IRepository;
public interface IColorRepository
{
    public Task<bool> ColorAddAsync(ColorAddDto colorAddDto,CancellationToken cancellationToken);
    public Task<List<ColorDto>> ColorGetAllAsync(ColorSearchDto colorSearchDto, CancellationToken cancellationToken);
    public Task<bool> ColorExistAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> ColorDeleteAsync(Guid id, CancellationToken cancellationToken);
}