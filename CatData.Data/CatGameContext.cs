using Cat.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatGame.Data
{
    public class CatGameContext: DbContext
    {

        public CatGameContext(DbContextOptions<CatGameContext> options): base(options) { }
        public DbSet<Kittys> CatDMs { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
