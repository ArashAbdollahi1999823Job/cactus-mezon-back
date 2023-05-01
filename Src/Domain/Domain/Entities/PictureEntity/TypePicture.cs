using Type = Domain.Entities.ProductEntity.Type;
namespace Domain.Entities.PictureEntity;
public class TypePicture
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }
    
    public TypePicture(string pictureTitle, string pictureAlt, string pictureUrl,int sort, Guid typeId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        TypeId = typeId;
        Sort = sort;
        CreationDate=DateTime.Now;
    }

    public Type Type { get; set; }
    public Guid TypeId { get; set; }

}