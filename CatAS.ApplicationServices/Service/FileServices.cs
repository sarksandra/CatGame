using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Data;
using Cat.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace   Cat.ApplicationServices.Services
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
        public void UploadFilesToDatabase(KittyDto dto, Kitty domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            HunterID = domain.ID
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabases.Add(files);

                    }
                }
            }
        }
       

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabases
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToDatabases.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;

        }
    }
}
