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
    //Base controller take the default business request (for static parts of the application)
    public abstract class BaseController : Controller
    {
        private signalContext _dbproxy;
        private emergncyDbContext _dbemergencyproxy;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected ISession _session => _httpContextAccessor.HttpContext.Session;


        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this._dbproxy = new signalContext();
            this._dbemergencyproxy = new emergncyDbContext();
        }
        public signalContext ormProxy
        {
            get
            {
                return _dbproxy;
            }
        }

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
