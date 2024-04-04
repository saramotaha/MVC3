using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace MVC3.PL.Helpers
{
    public static class documentSetting
    {

        public static async Task<string> UploadFile(IFormFile file, string folderName)
        {

            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            if(Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            string fileName =$"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";


            string filepath=Path.Combine(FolderPath, fileName);


            using var fileStream = new FileStream(filepath, FileMode.Create);


            await file.CopyToAsync(fileStream);


            return fileName;
        }




        public static void DeleteFile(string fileName , string folderName)
        {
            string filePath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files" ,folderName, fileName);

            if (File.Exists(filePath))
            { 
                File.Delete(filePath); 
            }

                

         
        }
    }
}
