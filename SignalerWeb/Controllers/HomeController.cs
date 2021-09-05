using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signaler.Library.Core;
using Signaler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Signaler.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            this.setPageTitle("Delete");

            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }


        //template method for setting the title of each page
        public override void setPageTitle(string actionRequester)
        {
            string _pageTitle = "";

            switch (actionRequester)
            {
                case "Index":
                    _pageTitle = "Home";
                    break;
                default:
                    _pageTitle = "Home";
                    break;
            }

            ViewBag.Title = _pageTitle;
        }
    }
}
