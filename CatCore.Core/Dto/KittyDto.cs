using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Dto
{
		public enum CharacterClass
		{
			Blight, Nurse, Survivor, Hillbilly
		}
		public enum CharacterStatus
		{
			Sacrificed, Downed, Injured, Healthy
		}
		public enum CharacterRank
		{
			Bronze, Iridescent, Gold, Silver
		}
		public class KittyDto
		{
			public Guid ID { get; set; }
			public string CharacterName { get; set; }
			public int CharacterXP { get; set; }
			public int CharacterXPNextLevel { get; set; }
			public int CharacterLevel { get; set; }
			public int CharacterMaxHealth { get; set; }
			public int CharacterHealth { get; set; }
			public CharacterClass CharacterClass { get; set; }
			public int PrimaryAttackPower { get; set; }
			public string PrimaryAttackName { get; set; }
			public int SpecialAttackPower { get; set; }
			public string SpecialAttackName { get; set; }
			public DateTime CharacterCreationTime { get; set; }
			public CharacterStatus CharacterStatus { get; set; }
			public CharacterRank CharacterRank { get; set; }
			//db only

			
			//IMAGE
			public List<IFormFile> Files {get; set;}
			public IEnumerable<FileToDatabaseDto> Image {get; set;} =  new List<FileToDatabaseDto>();

			public DateTime CreatedAt { get; set; }
			public DateTime UpdatedAt { get; set; }
		}
	}
