﻿using Core.Utilities.Results;
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
            var sourcePath = Path.GetTempFileName();

            if(file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(sourcePath, result.newPath);
            
            return result.imagePath;
        }

        public static string Update(string sourcePath,IFormFile file)
        {
            var result = NewPath(file);

            if(sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
         
            File.Delete(sourcePath);

            return result.imagePath;
        }

        public static void Delete(string sourcePath)
        {
            File.Delete(sourcePath);
        }

        public static (string newPath, string imagePath) NewPath(IFormFile file) //newPath-->resmin projeye kaydedildiği yol, imagePath-->resmin db'ye kaydedildiği yol
        {
            FileInfo fileInfo = new FileInfo(file.FileName); //dosya adı
            string fileExtension = fileInfo.Extension; //dosya uzantısı

            string path = Environment.CurrentDirectory + @"\wwwroot\img"; //yeni yol
            var name = Guid.NewGuid().ToString() + fileExtension; //yeni ad + dosya uzantısı
            string result = $@"{path}\{name}";

            return (result, $"\\img\\{name}");
        }
    }
}
