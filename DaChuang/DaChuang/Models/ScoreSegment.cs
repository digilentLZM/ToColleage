using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{

    [Table("ScoreSegment")]
    public partial class ScoreSegment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 3)]
        public double Score { get; set; }

        public int SegmentCount { get; set; }

        public int Count { get; set; }

        public virtual Province Province { get; set; }
    }
}
