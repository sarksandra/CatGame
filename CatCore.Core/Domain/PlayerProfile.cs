using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
    public enum ProfileStatus
    {
        Active, Abandoned
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; }
        public string ScreenName { get; set; }
        public int Gold {  get; set; }
        public int Momentos { get; set; }
        public int Victories { get; set; }
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType {  get; set; }
        public List<KittyOwnership> MyCharacters { get; set; }
    }
}
