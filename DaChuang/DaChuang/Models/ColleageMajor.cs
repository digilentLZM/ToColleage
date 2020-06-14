using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaChuang.Models
{

    [Table("ColleageMajor")]
    public partial class ColleageMajor
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ColleageCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string MajorCode { get; set; }

        public virtual Major Major { get; set; }

        public virtual Colleage Colleage{ get;  set;}
        //public virtual Colleage Colleage { get; set; }
    }
}
