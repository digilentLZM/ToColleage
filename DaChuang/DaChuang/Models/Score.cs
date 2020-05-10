using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    

    [Table("Score")]
    public partial class Score
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(600)]
        public string MajorInfo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BatchId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTypeId { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        public double? Average { get; set; }

        public double? MinScore { get; set; }

        public double? BatchScore { get; set; }

        public int? AverageUpRank { get; set; }

        public int? AverageDownRank { get; set; }

        public int? MinUpRank { get; set; }

        public int? MinDownRank { get; set; }

        public virtual Batch Batch { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Province Province { get; set; }

        public virtual StudentType StudentType { get; set; }
    }
}
