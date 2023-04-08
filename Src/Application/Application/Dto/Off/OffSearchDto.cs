namespace Application.Dto.Off;
public class OffSearchDto
{
    public long Id { get; set; }
    public Guid StoreId { get; set; }

    public OffSearchDto(long id, Guid storeId)
    {
        Id = id;
        StoreId = storeId;
    }

    public OffSearchDto()
    {

    }
}