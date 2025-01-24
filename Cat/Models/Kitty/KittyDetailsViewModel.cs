namespace Cat.Models.Kitty
{
    public class KittyDetailsViewModel
    {
        public Guid? ID { get; set; }
        public string CatName { get; set; }
        public int CatXP { get; set; }
        public int CatXPNextLevel { get; set; }
        public int CatLevel { get; set; }
        public CatStatus CatStatus { get; set; }
        public CatType CatType { get; set; }

        public List<KittyImageViewModel> Image { get; set; } = new List<KittyImageViewModel>();

    }
}
    