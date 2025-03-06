

namespace Cat.Models.Houses
{
	public enum HouseEffect
	{
		pink, purple, blue
	}
	public class HouseListIndexViewModel
	{
		public Guid ID { get; set; }
		public string HouseName { get; set; }
		public HouseEffect HouseEffect { get; set; }
		public int HouseLevelRequirement { get; set; }
		public List<IFormFile> Files { get; set; }
		public List<HouseImageViewModel> Image { get; set; } = new List<HouseImageViewModel>();
	}
}
