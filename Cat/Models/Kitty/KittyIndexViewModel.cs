using Microsoft.AspNetCore.Mvc;

namespace Cat.Models.Kitty
{
    public enum CatType
    {
        Orange, Black, Gray, White, Brown, Pink
    }
    public enum CatFoodType
    {
        Cake, Brownie, Muffin, Cookie, Candy, Chocolate, Waffle, IceCreame, Jelly, Pancake, Lollipop
    }
    public class KittyIndexViewModel
    {
        public Guid Id { get; set; }
        public string CatName { get; set; }
        public int CatFoodXP { get; set; }
        public int CatFoodXPNextLevel { get; set; }
        public int CatLevel { get; set; }
        public CatType CatType { get; set; }
        public CatFoodType CatFoodType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
