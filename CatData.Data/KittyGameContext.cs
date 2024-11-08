using Cat.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatGame.Data
{
    public class KittyGameContext: DbContext
    {

        public KittyGameContext(DbContextOptions<KittyGameContext> options): base(options) { }
        public DbSet<Kittys> Kittys { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
