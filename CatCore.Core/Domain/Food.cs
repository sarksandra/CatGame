using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
	public enum Foodtype
	{
        cupcake, icecream, candy, cake
    }
	public class Food
	{
        public Guid ID { get; set; }
        public string FoodName { get; set; }
        public Foodtype Foodtype { get; set; }
        public int FoodLevelRequirement { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
