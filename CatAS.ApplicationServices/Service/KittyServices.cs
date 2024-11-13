using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using CatGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cat.ApplicationServices.Service
{
    public class KittyServices : IKittysServices
    {
        private readonly KittyGameContext _context;
        private readonly IFileServices _fileServices;

        public KittyServices(KittyGameContext context, IFileServices fileServices )
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
        public async Task<Kittys> Create(KittyDto dto)
        {
            Kittys kittys = new Kittys();
            kittys.Id = Guid.NewGuid();
            kittys.CatName = dto.CatName;
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

        public async Task<Kittys> Update(KittyDto dto)
        {
            Kittys kittys = new Kittys();

            // set by service
            kittys.Id = dto.Id;
            kittys.CatFoodXPNextLevel = dto.CatFoodXPNextLevel;
            kittys.CatFoodXP = dto.CatFoodXP;
            kittys.CatLevel = dto.CatLevel;


            //set by user
            kittys.CatName = dto.CatName;
            kittys.CatType = (Core.Domain.CatType)dto.CatType;
            kittys.CatFoodType = (Core.Domain.CatFoodType)dto.CatFoodType;


            //set for db
            kittys.CreatedAt = dto.CreatedAt;
            kittys.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, kittys);
            }
            _context.Kittys.Update(kittys);
            await _context.SaveChangesAsync();
            
            return kittys;
        }
        public async Task<Kittys> Delete(Guid id)
        {
            var result = await _context.Kittys
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Kittys.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

       
    }
}
    

