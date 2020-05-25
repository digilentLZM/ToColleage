using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
   

    [Table("SpecialMajor")]
    public partial class SpecialMajor
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        public string Detail { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Major Major { get; set; }
    }
}
