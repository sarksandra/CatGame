using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using CatGame.Core.Domain;
using CatGame.Data;
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
        private readonly CatContext _context;
        public FileServices
       (
            IHostEnvironment webHost,
            CatContext context
       )
        {
            _webHost = webHost;
            _context = context;
        }
        public void UploadFilesToDatabase(CatDto dto, CatDM domain)
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
    }
   
}
