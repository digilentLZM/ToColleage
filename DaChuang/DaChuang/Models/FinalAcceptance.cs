using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinalAcceptance")]
    public partial class FinalAcceptance
    {
        [Key]
        [StringLength(14)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Required]
        [StringLength(12)]
        public string MajorCode { get; set; }

        public int year { get; set; }

        public float SumScore { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Major Major { get; set; }

        public virtual Student Student { get; set; }
    }
}
