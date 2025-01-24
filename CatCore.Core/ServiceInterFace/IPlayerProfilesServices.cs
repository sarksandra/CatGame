﻿using Cat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterface
{
    public interface IPlayerProfilesServices
    {
        Task<PlayerProfile> Create(string useridfor);
    }
}
