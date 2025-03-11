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
	public class FoodServices : IFoodsServices
	{
		private readonly KittyGameContext _context;
		private readonly IFoodsServices _foodsServices;
		private readonly IFileServices _fileServices;

		public FoodServices(KittyGameContext context, IFileServices fileServices)
		{
			_context = context;
			_fileServices = fileServices;
		}

		public async Task<Food> DetailsAsync(Guid id)
		{
			var result = await _context.Foods
				.FirstOrDefaultAsync(x => x.ID == id);
			return result;
		}
		public async Task<Food> Create (FoodDto dto)
		{
			Food realm = new();

			realm.ID = Guid.NewGuid();
			realm.FoodName = dto.FoodName;
			realm.Foodtype = (Core.Domain.Foodtype)dto.Foodtype;
			realm.FoodLevelRequirement = dto.FoodLevelRequirement;

			await _context.Foods.AddAsync(realm);
			await _context.SaveChangesAsync();

			return realm;
		}

        public async Task<Food> Update(FoodDto dto)
        {
            Food character = new Food();

            //Set by service
            character.ID = dto.ID;
            character.FoodName = dto.FoodName;
            character.FoodLevelRequirement = 100;
            character.Foodtype = (Core.Domain.Foodtype)dto.Foodtype;
            character.CreatedAt = DateTime.Now;

            //Set by user
            character.Foodtype = (Core.Domain.Foodtype)dto.Foodtype;
            character.FoodName = dto.FoodName;


            return character;
        }

        public async Task<Food> Delete(Guid id)
        {
            var result = await _context.Foods
               .FirstOrDefaultAsync(x => x.ID == id);
            _context.Foods.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
