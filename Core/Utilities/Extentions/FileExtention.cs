﻿using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Extentions
{
    public static class FileExtention
    {
        public static string CreateFile(this IFormFile formFile,string env,string path)
        {
            string fileName = $"{Guid.NewGuid()}{formFile.FileName}";
            string fullPath=Path.Combine(env,path,fileName);
            using (FileStream fileStream=new FileStream(fullPath,FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
