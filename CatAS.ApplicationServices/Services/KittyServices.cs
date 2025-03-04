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
	public class KittyServices : IKittysServices
	{
		private readonly KittyGameContext _context;
        private readonly IFileServices _fileServices;

        public KittyServices(KittyGameContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
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
            Kitty character = new();

            //Set by service
            character.ID = Guid.NewGuid();
            character.CharacterName = dto.CharacterName;
            character.CharacterHealth = 100;
            character.CharacterLevel = 0;
            character.CharacterXP = 0;
            character.CharacterXPNextLevel = 100;
            character.CharacterLevel = 0;
            character.CharacterStatus = (Cat.Core.Domain.CharacterStatus)3;
            character.CreatedAt = DateTime.Now;


            //Set by user
            character.CharacterClass = (Cat.Core.Domain.CharacterClass)dto.CharacterClass;
            character.PrimaryAttackName = dto.PrimaryAttackName;
            character.PrimaryAttackPower = dto.PrimaryAttackPower;
            character.SpecialAttackName = dto.SpecialAttackName;
            character.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            character.CreatedAt = DateTime.Now;
            character.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, character);
            }
            await _context.Kittys.AddAsync(character);
            await _context.SaveChangesAsync();

            return character;
        }
        public async Task<Kitty> Delete(Guid id)
        {
            var result = await _context.Kittys
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Kittys.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Kitty> Update(KittyDto dto)
        {
            Kitty character = new();

            //Set by service
            character.ID = Guid.NewGuid();
            character.CharacterName = dto.CharacterName;
            character.CharacterHealth = 100;
            character.CharacterLevel = 0;
            character.CharacterXP = 0;
            character.CharacterXPNextLevel = 100;
            character.CharacterLevel = 0;
            character.CharacterStatus = Cat.Core.Domain.CharacterStatus.Healthy;
            character.CreatedAt = DateTime.Now;


            //Set by user
            character.CharacterClass = (Cat.Core.Domain.CharacterClass)dto.CharacterClass;
            character.PrimaryAttackName = dto.PrimaryAttackName;
            character.PrimaryAttackPower = dto.PrimaryAttackPower;
            character.SpecialAttackName = dto.SpecialAttackName;
            character.SpecialAttackPower = dto.SpecialAttackPower;

            //set for db
            character.CreatedAt = DateTime.Now;
            character.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, character);
            }
            _context.Kittys.Update(character);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
