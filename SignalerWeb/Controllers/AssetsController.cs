using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signaler.Library.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Signaler.Services.assets;
using Signaler.Data.Models.assets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Signaler.Controllers
{
    public class AssetsController : BaseController<asset>
    {
        public AssetsController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public AssetsController(IassetService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor,service)
        {

        }

        // GET: /<controller>/
        public override IActionResult Index()
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

        public override IActionResult Create(asset model)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Update(asset model)
        {
            throw new NotImplementedException();
        }

        public override IActionResult View(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
