using Signaler.Services.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Services.Models.Assets
{
    public class assetServiceModel : ServiceModelBase
    {
        public string name { get; set; }

        public string symbol { get; set; }

        public DateTime createdDate { get; set; }

        //public ICollection<exchangemarket> markets { get; set; }
        //public ICollection<assetprice> prices { get; set; }
    }
}
