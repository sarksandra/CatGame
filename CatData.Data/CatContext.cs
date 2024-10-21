using Cat.Core.Domain;
using CatGame.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatGame.Data
{
    public class CatContext: DbContext
    {

        public CatContext(DbContextOptions<CatContext> options): base(options) { }
        public DbSet<CatDM> CatDMs { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
