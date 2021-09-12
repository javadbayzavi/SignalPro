using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class market : BaseEntity
    {
        [Required]
        public string name { get; set; }

        public ICollection<asset> assets { get; set; }
        public ICollection<exchangemarket> exchanges { get; set; }
    }
}
