using Application.Common.Helpers;
using Application.IContracts.IServices;

namespace WebApi.Contracts.Services
{
    public class FileUploader:IFileUploader
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public string Upload(IFormFile file,string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}/{path}";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = DateTime.Now.ToFileName()+"-"+file.FileName;

            var filePath = $"{directoryPath}//{fileName}";

            using var outPut=File.Create(filePath);
           // outPut.Close();
            file.CopyTo(outPut);
            

           return $"{path}/{fileName}";
        }

        public bool Delete(string path)
        {
            var finalPath = _webHostEnvironment.WebRootPath+"/" + path;
            File.Delete(finalPath);
               var check= File.Exists(finalPath);
               if (check) return false;
            return true;
        }
    }
}
