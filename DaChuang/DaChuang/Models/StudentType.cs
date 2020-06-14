using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
   

    [Table("StudentType")]
    public partial class StudentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentType()
        {
            Score = new HashSet<ColleageMajorLine>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentTypeDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColleageMajorLine> Score { get; set; }
    }
}
