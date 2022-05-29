using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.FileManager
{
    //интерфейс для сохранения картинок в папку
    public interface IFileManager
    {
        Task <string> SaveImage(IFormFile image);
    }
}
