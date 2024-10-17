using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGame.Core.Domain
{
    public enum CatType
    {
        Orange, Black, Gray, White, Brown, Pink
    }
    public enum CatFoodType
    {
        Cake, Brownie, Muffin, Cookie, Candy, Chocolate, Waffle, IceCreame, Jelly, Pancake, Lollipop
    }
    public class CatIndexViewModel
    {
        public Guid Id { get; set; }
        public string CatName { get; set; }
        public string CatFood { get; set; }
        public int CatFoodXP { get; set; }
        public int CatFoodXPNextLevel { get; set; }
        public int CatLevel { get; set; }
        public CatType CatType { get; }
        public CatFoodType CatFoodType { get; set; }

    }
}
