using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterFace
{
    public interface ICatsServices
    {
        Task<Cat> DetailsAsync(int id);
        Task<Cat> DetailsAsync(Guid id);
    }
}
