using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DaChuang.Models
{
    [Table("Major")]
    public partial class Major
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Major()
        {
            EnrollmentPlan = new HashSet<EnrollmentPlan>();
            FamousTeacher = new HashSet<FamousTeacher>();
            FinalAcceptance = new HashSet<FinalAcceptance>();
            MiddleSchoolMatriculateHistory = new HashSet<MiddleSchoolMatriculateHistory>();
            SpecialMajor = new HashSet<SpecialMajor>();
        }

        [Key]
        [StringLength(12)]
        [Display(Name = "专业代码")]
        public string MajorCode { get; set; }

        [Display(Name = "考研率")]
        public float? PostGraduateRate { get; set; }

        [Display(Name = "就业率")]
        public float? JobRate { get; set; }

        [Required]
        [Display(Name = "专业层次")]
        public string MajorLevel { get; set; }

        [Display(Name = "专业简介")]
        public string MajorIntro { get; set; }

        [Display(Name = "就业方向")]
        public string JobOrientation { get; set; }

        [Display(Name = "培养目标")]
        public string EducationObject { get; set; }

        [Display(Name = "主要课程")]
        public string MainCourses { get; set; }


        [Display(Name = "修业年限")]
        public string StudyYear { get; set; }

        [Display(Name = "授予学位")]
        public string Degree { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "专业类别编号")]
        public string MajorCategoryCode { get; set; }

        [Required]
        [Display(Name = "专业名称")]
        public string MajorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollmentPlan> EnrollmentPlan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamousTeacher> FamousTeacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinalAcceptance> FinalAcceptance { get; set; }

        public virtual MajorCategory MajorCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiddleSchoolMatriculateHistory> MiddleSchoolMatriculateHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialMajor> SpecialMajor { get; set; }
    }
}
