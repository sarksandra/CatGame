using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Dto
{
    public enum Foodtype
    {
        cupcake, icecream, candy, cake
    }
    public class FoodDto
    {
        public Guid ID { get; set; }
        public string FoodName { get; set; }
        public Foodtype Foodtype { get; set; }
        public int FoodLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
	}
}
