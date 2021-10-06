using Signaler.Library.Data.Core;
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
        public int pricedate { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        [ForeignKey("timeslotid")]
        public timeslot pricetype { get; set; }
        public long timeslotid { get; set; }

        public float openprice { get; set; }

        public float closeprice { get; set; }

        public float highprice { get; set; }

        public float lowprice { get; set; }

        [ForeignKey("assetid")]
        public asset asset { get; set; }
        public long assetid { get; set; }
    }
}
