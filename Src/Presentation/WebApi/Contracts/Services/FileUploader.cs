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
               var numbersSlash = path.LastIndexOf("/", StringComparison.Ordinal);
               var root = path.Substring(0, numbersSlash);
               DirectoryInfo dir = new DirectoryInfo(_webHostEnvironment.WebRootPath+"/" + root);
               int count = dir.GetFiles().Length;
               if (count==0)
               {
                   dir.Delete();
               }
               if (check) return false;
            return true;
        }
    }
}
