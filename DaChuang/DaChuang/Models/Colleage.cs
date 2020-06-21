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
        [Display(Name = "ѧУ����")]
        public string ColleageCode { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "���д���")]
        public string CityId { get; set; }

        [Required]
        [Display(Name = "��ѧ����")]
        public string ColleageName { get; set; }

        [Display(Name = "ѧУ���")]
        public string ShortName { get; set; }

        [Display(Name = "ѧУ����")]
        public string ColleageUrl { get; set; }

        [Display(Name = "ѧУˮƽ")]
        public string ColleageLevel { get; set; }

        [Display(Name = "ѧУ����")]
        public string ColleageType { get; set; }

        [Display(Name = "˶ʿ��")]
        public int? MasterCount { get; set; }

        [Display(Name = "��ʿ��")]
        public int? DoctorCount { get; set; }

        [Display(Name = "ѧУ��ַ")]
        public string Address { get; set; }

        [Display(Name = "������")]
        public float? PostgraduateRate { get; set; }

        [Display(Name = "��ҵ��")]
        public float? JobRate { get; set; }

        [Display(Name = "֪��У��")]
        public string FamousAlumni { get; set; }

        [Display(Name = "ѧУ����")]
        public string Belonging { get; set; }


        [Display(Name = "��ѧ����")]
        public string ColleageKind { get; set; }

        [StringLength(10)]
        [Display(Name = "ѧУ����")]
        public string ColleageId { get; set; }

        [Display(Name = "ѧУ���")]
        public string ColleageIntro { get; set; }

        [StringLength(4)]
        [Display(Name = "��������")]
        public string CreateDate { get; set; }

        [Display(Name = "У԰���")]
        public double? ColleageArea { get; set; }

        [StringLength(50)]
        [Display(Name = "�绰")]
        public string Phone { get; set; }

        [Display(Name = "�ص�ʵ��������")]
        public int? LabCount { get; set; }

        [Display(Name = "�ص�ѧ����")]
        public int? ImportantSubject { get; set; }

        [StringLength(30)]
        [Display(Name = "ѧ������")]
        public string StudentCount { get; set; }


        [Display(Name = "ѧУ����")]
        public string ColleagezsUrl { get; set; }


        [Display(Name = "Ժʿ��")]
        public int? AcademicianCount { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColleageMajorLine> Score { get; set; }
    }
}
