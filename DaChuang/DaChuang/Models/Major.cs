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
        [Key]
        [StringLength(12)]
        [Display(Name = "רҵ����")]
        public string MajorCode { get; set; }

        [Display(Name = "������")]
        public float? PostGraduateRate { get; set; }

        [Display(Name = "��ҵ��")]
        public float? JobRate { get; set; }

        [Required]
        [Display(Name = "רҵ���")]
        public string MajorLevel { get; set; }

        [Display(Name = "רҵ���")]
        public string MajorIntro { get; set; }

        [Display(Name = "��ҵ����")]
        public string JobOrientation { get; set; }

        [Display(Name = "����Ŀ��")]
        public string EducationObject { get; set; }

        [Display(Name = "��Ҫ�γ�")]
        public string MainCourses { get; set; }


        [Display(Name = "��ҵ����")]
        public string StudyYear { get; set; }

        [Display(Name = "����ѧλ")]
        public string Degree { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "רҵ�����")]
        public string MajorCategoryCode { get; set; }

        [Required]
        [Display(Name = "רҵ����")]
        public string MajorName { get; set; }

        public virtual MajorCategory MajorCategory { get; set; }
    }
}
