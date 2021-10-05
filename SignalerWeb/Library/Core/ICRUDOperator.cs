using Microsoft.AspNetCore.Mvc;
using Signaler.Services.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Signaler.Library.Core
{
    public interface ICRUDOperator<T_ServiceModel> where T_ServiceModel : ServiceModelBase
    {
        IActionResult Index();
        IActionResult Create(T_ServiceModel model);
        IActionResult Update(T_ServiceModel model);
        IActionResult View(int id);
        IActionResult Delete(int id);
    }
}
