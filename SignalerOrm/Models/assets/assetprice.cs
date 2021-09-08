using Signaler.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Signaler.Data.Models.assets
{
    public class assetprice : BaseEntity
    {
        [Required]
        public DateTime pricedate { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public timeslot pricetype { get; set; }

        public float open { get; set; }

        public float close { get; set; }

        public float high { get; set; }

        public float low { get; set; }

        [ForeignKey("assetid")]
        public asset asset { get; set; }
        public int assetid { get; set; }
    }
}
