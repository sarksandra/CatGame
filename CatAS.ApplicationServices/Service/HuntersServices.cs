using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.ServiceInterface;
using Cat.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.ApplicationServices.Services
{
    public class HuntersServices : IKittysServices
    {
        private readonly KittyGameContext _context;
        private readonly IFileServices _fileServices;

        public HuntersServices(KittyGameContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Kitty> DetailsAsync(Guid id)
        {
            var result = await _context.Kittys
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Kitty> Create(KittyDto dto)
        {
            Kitty hunter = new Kitty();

            hunter.ID = Guid.NewGuid();
            hunter.HunterHealth = 100;
            hunter.HunterXP = 0;
            hunter.HunterXPNextLevel = 100;
            hunter.HunterLevel = 0;
            hunter.HunterStatus = Core.Domain.HunterStatus.Alive;

            //set by user
            hunter.HunterName = dto.HunterName;
            hunter.PrimaryAttackName = dto.PrimaryAttackName;
            hunter.PrimaryAttackPower = dto.PrimaryAttackPower;
            hunter.SecondaryAttackName = dto.SecondaryAttackName;
            hunter.SecondaryAttackPower = dto.SecondaryAttackPower;
            hunter.SpecialAttackName = dto.SpecialAttackName;
            hunter.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            hunter.CreatedAt = DateTime.Now;
            hunter.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, hunter);
            }

            await _context.Kittys.AddAsync(hunter);
            await _context.SaveChangesAsync();

            return hunter;
        }

        public async Task<Kitty> Update(KittyDto dto)
        {
            Kitty hunter = new Kitty();

            // set by service
            hunter.ID = dto.ID;
            hunter.HunterHealth = dto.HunterHealth;
            hunter.HunterXP = dto.HunterXP;
            hunter.HunterXPNextLevel = dto.HunterXPNextLevel;
            hunter.HunterLevel = dto.HunterLevel;
            hunter.HunterStatus = (Core.Domain.HunterStatus)dto.HunterStatus;

            //set by user
            hunter.HunterName = dto.HunterName;
            hunter.PrimaryAttackName = dto.PrimaryAttackName;
            hunter.PrimaryAttackPower = dto.PrimaryAttackPower;
            hunter.SecondaryAttackName = dto.SecondaryAttackName;
            hunter.SecondaryAttackPower = dto.SecondaryAttackPower;
            hunter.SpecialAttackName = dto.SpecialAttackName;
            hunter.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            hunter.CreatedAt = dto.CreatedAt;
            hunter.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, hunter);
            }
            _context.Kittys.Update(hunter);
            await _context.SaveChangesAsync();

            return hunter;
        }

        public async Task<Kitty> Delete(Guid id)
        {
            var result = await _context.Kittys
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Kittys.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
