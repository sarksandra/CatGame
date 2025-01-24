﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Dto.AccountsDtos
{
    public class ApplicationUserDto
    {
        public string City {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid? AssociatedPlayerProfile {  get; set; }
        public bool ProfileType { get; set; } //true = admin, false =player
    }
}
