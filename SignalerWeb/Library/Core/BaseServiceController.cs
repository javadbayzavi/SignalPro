using Signaler.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signaler.Library.Services;
using Signaler.Library.Data.Core;

namespace Signaler.Library.Core
{

    //Base controller take the operational business request (for core business parts of the application)
    public abstract class BaseController<T> : BaseController where T: BaseEntity
    {

        protected readonly IService<T> _serviceProvider;


        public BaseController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public BaseController(IHttpContextAccessor httpContextAccessor, IService<T> service):base(httpContextAccessor)
        {
            this._serviceProvider = service;
        }

        public abstract IActionResult Index();
        public abstract IActionResult Create(T model);
        public abstract IActionResult Update(T model);
        public abstract IActionResult View(int id);
        public abstract IActionResult Delete(int id);
    }
}
