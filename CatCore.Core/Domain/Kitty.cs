using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
    public enum KittyType
    {
        Blight, Nurse, Survivor, Hillbilly
    }
    public enum KittyStatus
    {
        Full, Hungry
    }
    public enum KittyRank
    {
        Bronze, Iridescent, Gold, Silver
    }
    public class KittyListIndexViewModel
    {
        public Guid ID { get; set; }
        public string KittyName { get; set; }
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
        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

