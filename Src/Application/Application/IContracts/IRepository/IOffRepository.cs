using Application.Dto.Off;
namespace Application.IContracts.IRepository;
public interface IOffRepository
{
    public Task<List<OffDto>> OffGetAllAsync(OffSearchDto offSearchDto,CancellationToken cancellationToken);
    public Task<bool> OffAddAsync(OffAddDto offAddDto,CancellationToken cancellationToken);
    public Task<bool> OffEditAsync(OffEditDto offEditDto, CancellationToken cancellationToken);
    public Task<bool> OffExistAsync(long id, CancellationToken cancellationToken);
    public Task<bool> OffDeleteAsync(long id, CancellationToken cancellationToken);

}