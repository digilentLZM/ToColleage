using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    [Table("MiddleSchool")]
    public partial class MiddleSchool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MiddleSchool()
        {
            MiddleSchoolMatriculateHistory = new HashSet<MiddleSchoolMatriculateHistory>();
            Student = new HashSet<Student>();
        }

        [Key]
        [StringLength(10)]
        public string MiddleSchoolCode { get; set; }

        [StringLength(50)]
        public string MiddleSchoolName { get; set; }

        [Required]
        [StringLength(4)]
        public string CityId { get; set; }

        public float? YiBenRate { get; set; }

        public string IsImportant { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiddleSchoolMatriculateHistory> MiddleSchoolMatriculateHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
