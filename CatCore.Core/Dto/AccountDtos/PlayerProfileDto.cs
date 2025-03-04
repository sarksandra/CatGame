using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarCreek.Core.Dto.AccountsDtos
{
    public class PlayerProfileDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserID { get; set; }
        public string ScreenName { get; set; }
        public int Gold { get; set; }
        public bool ProfileType { get; set; } //true = admin
    }
}
