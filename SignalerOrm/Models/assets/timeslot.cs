using Signaler.Library.Data.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Signaler.Data.Models.assets
{
    public class timeslot : BaseEntity
    {
        [Required]
        [DataType(DataType.Text)]
        public string slotName { get; set; }

        public ICollection<asset> assets { get; set; }
    }
}