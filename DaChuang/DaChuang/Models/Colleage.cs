using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DaChuang.Models
{
  

    [Table("Colleage")]
    public partial class Colleage
    {

        [Key]
        [StringLength(10)]
        [Display(Name = "学校代码")]
        public string ColleageCode { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "城市代码")]
        public string CityId { get; set; }

        [Required]
        [Display(Name = "大学名称")]
        public string ColleageName { get; set; }

        [Display(Name = "学校简称")]
        public string ShortName { get; set; }

        [Display(Name = "学校官网")]
        public string ColleageUrl { get; set; }

        [Display(Name = "学校水平")]
        public string ColleageLevel { get; set; }

        [Display(Name = "学校类型")]
        public string ColleageType { get; set; }

        [Display(Name = "硕士点")]
        public int? MasterCount { get; set; }

        [Display(Name = "博士点")]
        public int? DoctorCount { get; set; }

        [Display(Name = "学校地址")]
        public string Address { get; set; }

        [Display(Name = "上研率")]
        public float? PostgraduateRate { get; set; }

        [Display(Name = "就业率")]
        public float? JobRate { get; set; }

        [Display(Name = "知名校友")]
        public string FamousAlumni { get; set; }

        [Display(Name = "学校隶属")]
        public string Belonging { get; set; }


        [Display(Name = "办学类型")]
        public string ColleageKind { get; set; }

        [StringLength(10)]
        [Display(Name = "学校代码")]
        public string ColleageId { get; set; }

        [Display(Name = "学校简介")]
        public string ColleageIntro { get; set; }

        [StringLength(4)]
        [Display(Name = "创办日期")]
        public string CreateDate { get; set; }

        [Display(Name = "校园面积")]
        public double? ColleageArea { get; set; }

        [StringLength(50)]
        [Display(Name = "电话")]
        public string Phone { get; set; }

        [Display(Name = "重点实验室数量")]
        public int? LabCount { get; set; }

        [Display(Name = "重点学科数")]
        public int? ImportantSubject { get; set; }

        [StringLength(30)]
        [Display(Name = "学生人数")]
        public string StudentCount { get; set; }


        [Display(Name = "学校官网")]
        public string ColleagezsUrl { get; set; }


        [Display(Name = "院士数")]
        public int? AcademicianCount { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColleageMajorLine> Score { get; set; }
    }
}
