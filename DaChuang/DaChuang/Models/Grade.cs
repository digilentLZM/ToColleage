using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Grade")]
    public partial class Grade
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        public float SumScore { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(14)]
        public string StudentId { get; set; }

        public int Rank { get; set; }

        public float Chinese { get; set; }

        public float Math { get; set; }

        public float English { get; set; }

        public float Grade1 { get; set; }

        public float Grade2 { get; set; }

        public float Grade3 { get; set; }

        [Required]
        [StringLength(1)]
        public string ChooseId1 { get; set; }

        [StringLength(1)]
        public string ChooseId2 { get; set; }

        [StringLength(1)]
        public string ChooseId3 { get; set; }

        public virtual Choice Choice { get; set; }

        public virtual Choice Choice1 { get; set; }

        public virtual Choice Choice2 { get; set; }

        public virtual Choice Choice3 { get; set; }

        public virtual Province Province { get; set; }

        public virtual Student Student { get; set; }

        public virtual SubjectChoose SubjectChoose { get; set; }
    }
}
