using Cat.Core.Domain;

namespace Cat.Models.Profile
{
    public class ProfileRegisterViewModel
    {
        public Guid Id { get; set; }
        public string ApplicationUserID { get; set; } // 1-1
        public string ScreenName { get; set; }
        public int ScrapResource { get; set; }
        public List<KittyOwnership> MyKittys { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public ProfileStatus CurrentStatus { get; set; }

        public bool ProfileType { get; set; } //true, admin, false, player
    }
}
