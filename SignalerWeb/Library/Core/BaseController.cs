using Signaler.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signaler.Services.Core;
using Signaler.Data.Core;

namespace Signaler.Library.Core
{
    public abstract class BaseController<T> : Controller where T: BaseEntity
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IService<T> _serviceProvider;
        protected ISession _session => _httpContextAccessor.HttpContext.Session;


        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this._dbproxy = new signalContext();
            this._dbemergencyproxy = new emergncyDbContext();
        }
        public BaseController(IHttpContextAccessor httpContextAccessor, IService<T> service)
        {
            this._serviceProvider = service;
            _httpContextAccessor = httpContextAccessor;
            this._dbproxy = new signalContext();
            this._dbemergencyproxy = new emergncyDbContext();
        }

        private signalContext _dbproxy;
        public signalContext ormProxy
        {
            get
            {
                return _dbproxy;
            }
        }

        private emergncyDbContext _dbemergencyproxy;
        public emergncyDbContext ormEmergencyProxy
        {
            get
            {
                return _dbemergencyproxy;
            }
        }
        public abstract void setPageTitle(string actionRequester);

    }
}
