using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
    public class KittyOwnership : Kittys
    {
        public Guid OwnershipID { get; set; }
        public int CatFoodXP { get; set; }
        public int CatFoodXPNextLevel { get; set; }
        public int CatLevel { get; set; }
        public DateTime TitanWasBorn { get; set; }
        public DateTime TitanDied { get; set; }
        //public string OwnedByPlayerProfile { get; set; } //is string but holds guid

        //db only
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
