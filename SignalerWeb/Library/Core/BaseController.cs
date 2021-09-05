using Signaler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Library.Core
{
    public abstract class BaseController : Controller
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected ISession _session => _httpContextAccessor.HttpContext.Session;


        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this._dbproxy = new discoveryContext();
            this._dbemergencyproxy = new emergncyDbContext();
        }

        private discoveryContext _dbproxy;
        public discoveryContext ormProxy
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
