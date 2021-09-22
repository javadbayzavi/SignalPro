using Signaler.Services.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Services.Models.Assets
{
    public class exchangeServiceModel : ServiceModelBase
    {
        public string Name { get; set; }
        public string url { get; set; }

        //public ICollection<exchangemarket> markets { get; set; }
        //public ICollection<exchangemarket> markets { get; set; }
        //public ICollection<assetprice> prices { get; set; }
    }
}
