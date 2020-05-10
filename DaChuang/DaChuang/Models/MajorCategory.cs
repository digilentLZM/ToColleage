using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{

    [Table("MajorCategory")]
    public partial class MajorCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MajorCategory()
        {
            Major = new HashSet<Major>();
        }

        [Required]
        public string MajorCategoryName { get; set; }

        [Key]
        [StringLength(4)]
        public string MajorCategoryCode { get; set; }

        [Required]
        [StringLength(2)]
        public string SubjectCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Major> Major { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
