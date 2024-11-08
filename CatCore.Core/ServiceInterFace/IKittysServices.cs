
using Cat.Core.Domain;
using Cat.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterFace
{
    public interface IKittysServices
    {
        Task<Kittys> Create(KittyDto dto);
        Task<Kittys> DetailsAsync(Guid id);
    }
}
