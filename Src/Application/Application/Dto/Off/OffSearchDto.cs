namespace Application.Dto.Off;
public class OffSearchDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }

    public OffSearchDto(Guid id, Guid storeId)
    {
        Id = id;
        StoreId = storeId;
    }

    public OffSearchDto()
    {

    }
}