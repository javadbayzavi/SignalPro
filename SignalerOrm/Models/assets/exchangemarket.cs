using Signaler.Data.Core;
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
        public exchage exchage { get; set; }
        [Required]
        public int exchangeid { get; set; }

        [ForeignKey("marketid")]
        public market market { get; set; }
        [Required]
        public int marketid { get; set; }
    }
}
