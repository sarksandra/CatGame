using Cat.Core.Domain;
using Cat.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(KittyDto dto, Kitty domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
