using Signaler.Library.Repositories;
using Signaler.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signaler.Library.Services.Core
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
