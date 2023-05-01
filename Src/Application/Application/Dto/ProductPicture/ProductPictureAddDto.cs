using Microsoft.AspNetCore.Http;

namespace Application.Dto.ProductPicture;
public class ProductPictureAddDto
{
    public string PictureTitle { get; set; }
    public string PictureAlt { get; set; }
    public IFormFile PictureUrl { get; set; }
    public string PictureUrlString { get; set; }
    public int Sort { get; set; }
    public Guid ProductId { get; set; }

    public ProductPictureAddDto(string pictureTitle, string pictureAlt, string pictureUrlString, int sort, Guid productId)
    {
        PictureTitle = pictureTitle;
        PictureAlt = pictureAlt;
        PictureUrlString = pictureUrlString;
        Sort = sort;
        ProductId = productId;
    }

    public ProductPictureAddDto()
    {
        
    }
}