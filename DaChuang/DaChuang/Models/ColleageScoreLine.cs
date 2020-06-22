using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DaChuang.Models
{
    

    [Table("ColleageScoreLine")]
    public partial class ColleageScoreLine
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        [Display(Name = "ԺУ����")]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTypeId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "���")]
        public int Year { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BatchId { get; set; }

        [Display(Name = "��߷�")]
        public double? MaxScore { get; set; }
        //public double? MinScore { get; set; }

        [Display(Name = "ƽ����")]
        public decimal? Average { get; set; }


        [Display(Name = "������")]
        public double? BatchScore { get; set; }
        public virtual Colleage Colleage { get; set; }

        public virtual Province Province { get; set; }

        public virtual StudentType StudentType { get; set; }

        public virtual Batch Batch { get; set; }
    }
}
