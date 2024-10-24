namespace Cat.Models.Kitty
{
    public class KittyImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public string ImageData { get; set; }
        public string Image { get; set; }
        public Guid? CatID { get; set; }
    }
}
