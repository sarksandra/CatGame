using Cat.Core.Domain;

namespace Cat.Models.Realms
{
	public class HouseCreateViewModel
	{
		public Guid ID { get; set; }
		public string RealmName { get; set; }
		public RealmEffect RealmEffect { get; set; }
		public int CharacterLevelRequirement { get; set; }
		public List<IFormFile> Files { get; set; }
		public List<HouseImageViewModel> Image { get; set; } = new List<HouseImageViewModel>();

    }
}
