using Cat.Core.Domain;
using Cat.Core.Dto;

namespace Cat.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(KittyDto dto, Kitty character);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
