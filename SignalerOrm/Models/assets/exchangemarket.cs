using Signaler.Library.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class exchangemarket : BaseEntity
    {
        [ForeignKey("exchangeid")]
        public exchange exchage { get; set; }
        [Required]
        public long exchangeid { get; set; }

        [ForeignKey("marketid")]
        public market market { get; set; }
        [Required]
        public long marketid { get; set; }
    }
}
