using GenericCrudApi.Controllers;
using Signaler.Data.Models.assets;
using Signaler.Services.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singaler.api.Controllers
{
    public class AssetsController : ApiControllerBase<asset>
    {
        public AssetsController(IassetService service) : base(service)
        {

        }
    }
}
