

namespace Cat.Models.Realms
{
	public enum HouseEffect
	{
		Frozen, Eclipsed, Normal
	}
	public class HouseListIndexViewModel
	{
		public Guid ID { get; set; }
		public string HouseName { get; set; }
		public HouseEffect HouseEffect { get; set; }
		public int CharacterLevelRequirement { get; set; }
		public List<IFormFile> Files { get; set; }
		public List<HouseImageViewModel> Image { get; set; } = new List<HouseImageViewModel>();
	}
}
