using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Services
{
    public interface IFilesManager
    {
        string UploadFiles(IFormFile file) ;
        FileStream GetFile(string fileName);
    }
}
