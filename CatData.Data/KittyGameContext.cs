﻿using Cat.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cat.Data
{
    public class KittyGameContext: IdentityDbContext<ApplicationUser>
    {

        public KittyGameContext(DbContextOptions<KittyGameContext> options): base(options) { }
        public DbSet<Kitty> Kittys { get; set; }
        public DbSet<FileToDatabase> FilesToDatabases { get; set; }
        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
    }
}
