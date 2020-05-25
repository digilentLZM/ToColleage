using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
   

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Grade = new HashSet<Grade>();
        }

        [StringLength(14)]
        public string StudentId { get; set; }

        [StringLength(10)]
        public string MiddleSchoolCode { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        public virtual FinalAcceptance FinalAcceptance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grade { get; set; }

        public virtual MiddleSchool MiddleSchool { get; set; }
    }
}
