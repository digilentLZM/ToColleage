using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaChuang.Models
{
   

    [Table("City")]
    public partial class City
    {

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
    }
}
