using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaChuang.Models
{


    [Table("ColleageShortInfo")]
    public partial class ColleageShortInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ColleageName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string CityId { get; set; }

        public string ColleageType { get; set; }

        public string ColleageLevel { get; set; }

        public string Belonging { get; set; }

        public string ColleageKind { get; set; }

        public virtual City City { get; set; }
    }
}
