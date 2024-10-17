using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatGame.Data
{
    public class CatContext
    {
        public DbSet<CatDM> CatDMs { get; set; }
    }
}
