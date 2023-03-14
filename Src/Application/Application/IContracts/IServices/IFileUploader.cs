using Microsoft.AspNetCore.Http;

namespace Application.IContracts.IServices
{
    public interface IFileUploader
    {
       public string Upload(IFormFile file,string path);
       public bool Delete(string path);

    }
}
