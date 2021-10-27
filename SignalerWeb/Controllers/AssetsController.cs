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
    //public class AssetsController : BaseController<assetService>
    public class AssetsController : BaseController<assetServiceModel>
    {
        public AssetsController(assetService service, IHttpContextAccessor httpContextAccessor) : base(service.ServiceProxyInterface,httpContextAccessor)
        {
            //this._serviceProvider = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            this.setPageTitle("Index");

            var items = this._serviceProvider.GetItems().Select(item => new assetViewModel()
            {
                Id = item.Id,
                name=  item.name,
                symbol = item.symbol
            });
            
            

            return View(items);
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(assetViewModel asset)
        {
            //TODO : Provide a created date vaue for input model
            if(this.ModelState.IsValid)
            {
                await this._serviceProvider.InsertAsync(new assetServiceModel()
                {
                    name = asset.name,
                    symbol = asset.symbol
                });
            }
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

        public IActionResult View(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            //this._serviceProvider.Delete();
            return View();
        }

        public IActionResult Update(assetServiceModel model)
        {
            return View();
        }
    }
}
