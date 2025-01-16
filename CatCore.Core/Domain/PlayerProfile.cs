﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Domain
{
    public enum ProfileStatus
    {
        Active, Abandoned, Deactivated, Locked, Banned, ManualReviewNecessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; } // 1-1
        public string ScreenName { get; set; }
        public int KittyCredits { get; set; }
        public int ScrapResource { get; set; }
        public List<KittyOwnership> MyKittys { get; set; }
        public int Victories { get; set; }
        
        public ProfileStatus CurrentStatus { get; set; }

        public bool ProfileType { get; set; } //true, admin, false, player

        //dbonly
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }

    }
}
