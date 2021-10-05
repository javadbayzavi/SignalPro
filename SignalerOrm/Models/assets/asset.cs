using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class asset : BaseEntity
    {

        [Required]
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Text)] 
        public string symbol { get; set; }

        public ICollection<exchangemarket> markets { get; set; }
        public ICollection<assetprice> prices { get; set; }

    }
}
