using Application.Dto.Off;
namespace Application.IContracts.IRepository;
public interface IOffRepository
{
    public Task<List<OffDto>> OffGetAllAsync(OffSearchDto offSearchDto,CancellationToken cancellationToken);
    public Task<bool> OffAddAsync(OffAddDto offAddDto,CancellationToken cancellationToken);
    public Task<bool> OffEditAsync(OffEditDto offEditDto, CancellationToken cancellationToken);
    public Task<bool> OffExistAsync(Guid id, CancellationToken cancellationToken);
    public Task<bool> OffDeleteAsync(Guid id, CancellationToken cancellationToken);

}