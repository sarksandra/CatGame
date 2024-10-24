using Cat.Core.Domain;
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
    public class KittyServices : ICatsServices
    {
        private readonly CatGameContext _context;
        //private readonly IFileServices _fileServices;

        public KittyServices(CatGameContext context /*IFileServices fileServices */)
        {
            _context = context;
            //_fileServices = fileServices;
        }
        public async Task<Kittys> DetailsAsync(Guid id)
        {
            var result = await _context.CatDMs
                .FirstOrDefaultAsync(x => x.Id == id);
            return result ;
        }

        Task<Kittys> ICatsServices.DetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
