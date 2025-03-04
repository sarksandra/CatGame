using Cat.Core.Domain;

namespace Cat.Models.Houses
{
    public class HouseDetailsViewModel
    {
        public Guid ID { get; set; }
        public string HouseName { get; set; }
        public HouseEffect HouseEffect { get; set; }
        public int KittyLevelRequirement { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<HouseImageViewModel> Image { get; set; } = new List<HouseImageViewModel>();
    }
}
