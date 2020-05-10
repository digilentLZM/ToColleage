using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaChuang.Models
{
    [Table("MajorShortInfo")]
    public partial class MajorShortInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public string MajorName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string MajorCategoryCode { get; set; }

        public string MajorLevel { get; set; }


        public virtual MajorCategory MajorCategory { get; set; }
        
    }
}
