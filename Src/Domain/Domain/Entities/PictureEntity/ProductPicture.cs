using Domain.Entities.ProductEntity;
namespace Domain.Entities.PictureEntity;
public class ProductPicture
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? LastModified { get; set; }
    public DateTime CreationDate { get; set; }
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public string PictureUrl { get; set; }
    public int Sort { get; set; }

    public ProductPicture(string pictureTitle, string pictureAlt, string pictureUrl, int sort, Guid productId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrl = pictureUrl;
        Sort = sort;
        ProductId = productId;
    }

    public Product Product { get; set; }
    public Guid ProductId { get; set; }
}

