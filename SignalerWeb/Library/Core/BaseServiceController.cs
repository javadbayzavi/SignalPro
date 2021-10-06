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
using Signaler.Services.Library;
using Signaler.Library.Data.Core;

namespace Signaler.Library.Core
{

    //Base controller take the operational business request (for core business parts of the application)
    //public abstract class BaseController<T_Service> : BaseController where T_Service : IServable
    public abstract class BaseController<T_ServiceModel> : BaseController, ICRUDOperator<T_ServiceModel> where T_ServiceModel : ServiceModelBase
    {

        //protected readonly T_Service _serviceProvider;
        protected readonly IService<T_ServiceModel> _serviceProvider;

        //public BaseController(T_Service service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        public BaseController(IService<T_ServiceModel> service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this._serviceProvider = service;
        }

        public virtual IActionResult Index() { return View(); }
        public virtual IActionResult Create(T_ServiceModel model) { return View(); }
        public virtual IActionResult Update(T_ServiceModel model) { return View(); }
        public virtual IActionResult View(int id) { return View(); }
        public virtual IActionResult Delete(int id) { return View(); }
    }
}
