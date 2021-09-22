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
    public abstract class BaseController<T_ServiceModel> : BaseController where T_ServiceModel : ServiceModelBase
    {

        //protected readonly IService<T_ServiceModel> _serviceProvider;
        protected readonly IService<T_ServiceModel> _serviceProvider;

        public BaseController(IHttpContextAccessor httpContextAccessor, IService<T_ServiceModel> service):base(httpContextAccessor)
        {
            this._serviceProvider = service;
        }

        public abstract IActionResult Index();
        public abstract IActionResult Create(T_ServiceModel model);
        public abstract IActionResult Update(T_ServiceModel model);
        public abstract IActionResult View(int id);
        public abstract IActionResult Delete(int id);
    }
}
