using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Data.Models.identity
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; }
        public IList<RoleClaimsViewModel> RoleClaims { get; set; }
    }
}
