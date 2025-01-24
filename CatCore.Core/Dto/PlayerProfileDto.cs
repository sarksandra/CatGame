using Cat.Core.Domain;

namespace Cat.Core.Dto
{
    public class PlayerProfileDto
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; } 
        public string ScreenName { get; set; }
        public int HunterCredits { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public string? MyBuilding { get; set; } 
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType { get; set; }
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }
    }
}
