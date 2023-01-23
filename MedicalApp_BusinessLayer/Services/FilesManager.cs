using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Services
{
    public class FilesManager : IFilesManager
    {
        public FileStream GetFile(string fileName)
        {
          
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var dbPath = Path.Combine(pathToSave, fileName);
            var fileStream = new FileStream(dbPath, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

        public  string UploadFiles(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName =Guid.NewGuid().ToString() + 
                ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName!.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                 file.CopyTo(stream);
            }

            return fileName;
        }
    }
}
