namespace Application.Dto.Off;
public class OffSearchDto
{
    public long Id { get; set; }
    public long StoreId { get; set; }

    public OffSearchDto(long id, long storeId)
    {
        Id = id;
        StoreId = storeId;
    }

    public OffSearchDto()
    {

    }
}