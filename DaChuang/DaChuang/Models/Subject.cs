namespace DaChuang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        [Key]
        [StringLength(2)]
        public string SubjectCode { get; set; }

        [Required]
        public string SubjectName { get; set; }
    }
}
