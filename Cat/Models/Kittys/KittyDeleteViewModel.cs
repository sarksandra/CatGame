namespace Cat.Models.Kittys
{
	public class KittyDeleteViewModel
	{
        public Guid ID { get; set; }
        public string Kittyname { get; set; }
        public int KittyXP { get; set; }
        public int KittyXPNextLevel { get; set; }
        public int KittyLevel { get; set; }
        public KittyType KittyType { get; set; }
        public int FoodPower { get; set; }
        public string FoodName { get; set; }
        public int SpecialFood { get; set; }
        public string SpecialFoodName { get; set; }
        public DateTime CreationTime { get; set; }
        public KittyStatus KittyStatus { get; set; }
        public KittyRank KittyRank { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<KittyImageViewModel> Image { get; set; } = new List<KittyImageViewModel>();
        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
