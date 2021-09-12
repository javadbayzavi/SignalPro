using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class exchage : BaseEntity
    {
        public string Name { get; set; }
        public string url { get; set; }

        public ICollection<exchangemarket> markets { get; set; }
    }
}
