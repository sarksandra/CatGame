﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
	public enum HouseEffect
	{
		purple, pink, blue
	}
	public class House
	{
		public Guid ID { get; set; }
		public string KittyName { get; set; }
		public HouseEffect HouseEffect { get; set; }
		public int CharacterLevelRequirement { get; set; }
		public DateTime CreatedAt { get; set; }
    }
}
