using Cat.Core.Domain;
using Cat.Core.Dto.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterFace
{
    public interface IAccountsServices
    {
        Task<ApplicationUser> Register(ApplicationUserDto dto);
        Task<ApplicationUser> ConfirmedEmail(string userId, string token);
        Task<ApplicationUser> LogIn(LogInDto dto);

    }
}
