using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using CatGame.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cat.ApplicationServices.Service
{
    public class KittyServices : IKittysServices
    {
        private readonly CatGameContext _context;
        private readonly IFileServices _fileServices;

        public KittyServices(CatGameContext context, IFileServices fileServices )
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Kittys> DetailsAsync(Guid id)
        {
            var result = await _context.Kittys
                .FirstOrDefaultAsync(x => x.Id == id);
            return result ;
        }

        Task<Kittys> IKittysServices.DetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<Kittys> Create(CatDto dto)
        {
            Kittys kittys = new Kittys();
            kittys.Id = Guid.NewGuid();
            kittys.CatFoodXP = 0;
            kittys.CatLevel = 0;
            kittys.CatFoodXPNextLevel = 0;

            

            kittys.CatType = (Core.Domain.CatType)dto.CatType;
            kittys.CatFoodType = (Core.Domain.CatFoodType)dto.CatFoodType;

            kittys.CreatedAt = DateTime.Now;
            kittys.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, kittys);
            }
            await _context.Kittys.AddAsync(kittys);
            await _context.SaveChangesAsync();
            return kittys;
        }
    }
}
