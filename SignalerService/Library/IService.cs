using Signaler.Library.Data.Core;
using Signaler.Data.Models.assets;
using Signaler.Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signaler.Library.Services
{
    public interface IService<T> where T: BaseEntity
    {
    }
}
