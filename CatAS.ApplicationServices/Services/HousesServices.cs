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
	public class HousesServices : IHousesServices
	{
		private readonly KittyGameContext _context;
		private readonly IHousesServices _realmsServices;
		private readonly IFileServices _fileServices;

		public HousesServices(KittyGameContext context, IFileServices fileServices)
		{
			_context = context;
			_fileServices = fileServices;
		}

		public async Task<House> DetailsAsync(Guid id)
		{
			var result = await _context.Houses
				.FirstOrDefaultAsync(x => x.ID == id);
			return result;
		}
		public async Task<House> Create (HouseDto dto)
		{
			House realm = new();

			realm.ID = Guid.NewGuid();
			realm.HouseName = dto.HouseName;
			realm.House = (HouseEffect)dto.HouseEffect;
			realm.CharacterLevelRequirement = dto.CharacterLevelRequirement;

			await _context.Realms.AddAsync(realm);
			await _context.SaveChangesAsync();

			return realm;
		}
	}
}
