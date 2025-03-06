using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Dto
{
	public enum HouseEffect
	{
		purple, pink, blue
	}
	public class HouseDto
	{
		public Guid ID { get; set; }
		public string HouseName { get; set; }
		public HouseEffect HouseEffect { get; set; }
		public int HouseLevelRequirement { get; set; }
		public List<IFormFile> Files { get; set; }
		public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
	}
}
