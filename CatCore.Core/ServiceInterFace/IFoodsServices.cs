using Cat.Core.Domain;
using Cat.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterface
{
	public interface IFoodsServices
	{
		Task<Food> Create(FoodDto dto);
		Task<Food> Update(FoodDto dto);
		Task<Food> Delete(Guid id);
		Task<Food> DetailsAsync(Guid id);
        
    }
}
