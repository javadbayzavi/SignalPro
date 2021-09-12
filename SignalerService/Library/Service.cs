using Signaler.Library.Data.Core;
using Signaler.Data.Models.assets;
using Signaler.Library.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signaler.Library.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        public Service(IRepository<T> repo)
        {
            this.repository = repo;
        }

        protected IRepository<T> repository { get; set; }
    }
}
