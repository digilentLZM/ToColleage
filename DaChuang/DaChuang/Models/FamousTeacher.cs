using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FamousTeacher")]
    public partial class FamousTeacher
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(2)]
        public string Sex { get; set; }

        public short Age { get; set; }

        [Required]
        public string ProfessionTitle { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string AcademicianType { get; set; }

        public virtual Colleage Colleage { get; set; }

        public virtual Major Major { get; set; }
    }
}
