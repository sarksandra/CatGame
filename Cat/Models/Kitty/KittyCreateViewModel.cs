using Cat.Core.Dto;

namespace Cat.Models.Kitty
{
    public class KittyCreateViewModel
    {
        public Guid Id { get; set; }
        public string CatName { get; set; }
        public int CatFoodXP { get; set; }
        public int CatFoodXPNextLevel { get; set; }
        public int CatLevel { get; set; }
        public CatType CatType { get; set; }
        public CatFoodType CatFoodType { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<KittyImageViewModel> Image { get; set; } = new List<KittyImageViewModel>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
