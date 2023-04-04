namespace Application.Dto.Off;

public class OffEditDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OffPercent { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public OffEditDto(long id, string name, string description, int offPercent, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Name = name;
        Description = description;
        OffPercent = offPercent;
        StartDate = startDate;
        EndDate = endDate;
    }

    public OffEditDto()
    {
        
    }
}