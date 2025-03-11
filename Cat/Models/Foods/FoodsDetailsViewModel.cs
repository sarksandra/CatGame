using Cat.Core.Domain;

namespace Cat.Models.Foods
{
    public class FoodsDetailsViewModel
    {
        public Guid ID { get; set; }
        public string FoodName { get; set; }
        public Foodtype Foodtype { get; set; }
        public int FoodLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FoodsImageViewModel> Image { get; set; } = new List<FoodsImageViewModel>();
    }
}
