using Cat.Core.Domain;
using Cat.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterface
{
	public interface IKittysServices
	{
		Task<Kitty> DetailsAsync(Guid id);
		Task<Kitty> Create(KittyDto dto);
		Task<Kitty> Delete(Guid id);
		Task<Kitty>Update(KittyDto dto);
	}
}
