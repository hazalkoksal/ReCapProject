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
            var sourcePath = Path.GetTempFileName();

            if(file.Length > 0)
            {
                using(var stream = new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static string Update(string sourcePath,IFormFile file)
        {
            var result = newPath(file);

            if(sourcePath.Length > 0)
            {
                using(var stream = new FileStream(result,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return result;
        }

        public static IResult Delete(string sourcePath)
        {
            try
            {
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string newPath(IFormFile file)
        {
            FileInfo fi = new FileInfo(file.FileName);
            string fileExtension = fi.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var newPath = Guid.NewGuid().ToString() + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
