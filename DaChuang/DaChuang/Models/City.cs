using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaChuang.Models
{
   

    [Table("City")]
    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Colleage = new HashSet<Colleage>();
            MiddleSchool = new HashSet<MiddleSchool>();
        }

        [StringLength(4)]
        public string CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        [StringLength(2)]
        public string ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colleage> Colleage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiddleSchool> MiddleSchool { get; set; }
    }
}
