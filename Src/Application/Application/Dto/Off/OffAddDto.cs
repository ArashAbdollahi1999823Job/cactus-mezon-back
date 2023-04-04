namespace Application.Dto.Off;

public class OffAddDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPercent { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public long  StoreId { get; set; }

    public OffAddDto(string name, string description, int offPercent, DateTime startDate, DateTime endDate, long storeId)
    {
        Name = name;
        Description = description;
        OffPercent = offPercent;
        StartDate = startDate;
        EndDate = endDate;
        StoreId = storeId;
    }

    public OffAddDto()
    {
        
    }
}