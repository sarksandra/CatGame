

namespace Cat.Models.Foods
{
	public enum Foodtype
	{
		cupcake, icecream, candy, cake
	}
	public class FoodsListIndexViewModel
	{
		public Guid ID { get; set; }
		public string FoodName { get; set; }
		public Foodtype Foodtype { get; set; }
		public int FoodLevelRequirement { get; set; }
		public List<IFormFile> Files { get; set; }
		public List<FoodsImageViewModel> Image { get; set; } = new List<FoodsImageViewModel>();
	}
}
