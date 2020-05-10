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

    [Table("EnrollmentPlan")]
    public partial class EnrollmentPlan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BatchId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        [Required]
        [StringLength(20)]
        public string Batch { get; set; }

        public int PlanNumber { get; set; }

        [Required]
        public string Limitations { get; set; }

        public virtual Batch Batch1 { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Major Major { get; set; }

        public virtual Province Province { get; set; }
    }
}
