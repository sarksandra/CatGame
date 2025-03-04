using Cat.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cat.Data
{
    public class KittyGameContext : IdentityDbContext<ApplicationUser>
    {
        public KittyGameContext(DbContextOptions<KittyGameContext> options) : base(options) { }
        public DbSet<Kitty> Kittys { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
