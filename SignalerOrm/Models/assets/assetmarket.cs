using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class assetmarket : BaseEntity
    {

        [ForeignKey("assetid")]
        public asset asset { get; set; }
        [Required]
        public int assetid { get; set; }

        [ForeignKey("marketid")]
        public market market { get; set; }
        [Required]
        public int marketid { get; set; }
    }
}
