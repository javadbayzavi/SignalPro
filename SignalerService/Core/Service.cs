﻿using Signaler.Data.Core;
using Signaler.Data.Models.assets;
using Signaler.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signaler.Services.Core
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
