using Cat.Core.ServiceInterFace;
using CatGame.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cat.ApplicationServices.Service
{
    public class CatsServices : ICatsServices
    {
        private readonly CatContext _context;
        //private readonly IFileServices _fileServices;

        public CatsServices(CatContext context /*IFileServices fileServices */)
        {
            _context = context;
            //_fileServices = fileServices;
        }
        public async Task<CatDM> DetailsAsync(Guid id)
        {
            var result = await _context.Cats
                .FirstOrDefaultAsync(x => x.Id == id);
            return result ;
        }

    }
}
