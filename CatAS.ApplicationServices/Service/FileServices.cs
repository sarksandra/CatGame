using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using CatGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.ApplicationServices.Service
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly KittyGameContext _context;
        public FileServices
       (
            IHostEnvironment webHost,
            KittyGameContext context
       )
        {
            _webHost = webHost;
            _context = context;
        }
        public void UploadFilesToDatabase(KittyDto dto, Kittys domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            CatID = Guid.NewGuid(),
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabase dto)
        {
            var imageID = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            var filePath = _webHost.ContentRootPath + "\\ multipleFileUpload\\" + imageID.ExistingFilePath;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

            }
            _context.FilesToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();
            return null;
        }
    }
   
}
