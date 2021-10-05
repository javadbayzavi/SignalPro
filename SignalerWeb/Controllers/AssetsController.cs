using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Signaler.Library.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Signaler.Services.assets;
using Signaler.Models.Assets;
using Signaler.Library.Services;
using Signaler.Services.Models.Assets;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Signaler.Controllers
{
    public class AssetsController : BaseController<assetServiceModel>
    {
        public AssetsController(assetService service, IHttpContextAccessor httpContextAccessor) : base(service.ServiceProxy,httpContextAccessor)
        {
        }

        // GET: /<controller>/
        public override IActionResult Index()
        {
            this.setPageTitle("Index");
            //this._serviceProvider.Delete()
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

        public override IActionResult View(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            //this._serviceProvider.Delete();
            return View();
        }

        public override IActionResult Create(assetServiceModel model)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Update(assetServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
