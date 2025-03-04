using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
	public enum RealmEffect
	{
		Frozen, Eclipsed, Normal
	}
	public class House
	{
		public Guid ID { get; set; }
		public string HouseName { get; set; }
		public RealmEffect HouseEffect { get; set; }
		public int CharacterLevelRequirement { get; set; }
		public DateTime CreatedAt { get; set; }
    }
}
