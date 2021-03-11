using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = NewPath(file);

            using (var stream = new FileStream(result, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return result;
        }

        public static string Update(string sourcePath,IFormFile file)
        {
            var result = NewPath(file);

            using (var stream = new FileStream(result, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            File.Delete(sourcePath);
            return result;
        }

        public static void Delete(string sourcePath)
        {
            File.Delete(sourcePath);
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName); //dosya adı
            string fileExtension = fileInfo.Extension; //dosya uzantısı

            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads"; //yeni yol
            var name = Guid.NewGuid().ToString() + fileExtension; //yeni ad + dosya uzantısı

            string result = $@"{path}\{name}";
            return result;
        }
    }
}
