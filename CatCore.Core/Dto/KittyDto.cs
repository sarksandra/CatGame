﻿using Microsoft.AspNetCore.Http;


namespace Cat.Core.Dto
{
    public enum HunterStatus
    {
        Dead, Alive
    }
    public class KittyDto
    {
        public Guid ID { get; set; }
        public string HunterName { get; set; }
        public int HunterHealth { get; set; }
        public int HunterXP { get; set; }
        public int HunterXPNextLevel { get; set; }
        public int HunterLevel { get; set; }
        public HunterStatus HunterStatus { get; set; }
        public int PrimaryAttackPower { get; set; }
        public string PrimaryAttackName { get; set; }
        public int SecondaryAttackPower { get; set; }
        public string SecondaryAttackName { get; set; }
        public int SpecialAttackPower { get; set; }
        public string SpecialAttackName { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
