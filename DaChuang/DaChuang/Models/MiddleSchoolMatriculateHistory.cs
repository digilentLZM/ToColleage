using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
   

    [Table("MiddleSchoolMatriculateHistory")]
    public partial class MiddleSchoolMatriculateHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MiddleSchoolCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        public float Score { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Major Major { get; set; }

        public virtual MiddleSchool MiddleSchool { get; set; }
    }
}
