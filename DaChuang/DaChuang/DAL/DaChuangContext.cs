using System.Data.Entity;
using DaChuang.Models;

namespace DaChuang.DAL
{
    public partial class DaChuangContext : DbContext
    {
        public DaChuangContext()
            : base("name=DaChuang")
        {
        }

        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<Choice> Choice { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Colleage> Colleage { get; set; }
        public virtual DbSet<EnrollmentPlan> EnrollmentPlan { get; set; }
        public virtual DbSet<FamousTeacher> FamousTeacher { get; set; }
        public virtual DbSet<FinalAcceptance> FinalAcceptance { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MajorCategory> MajorCategory { get; set; }
        public virtual DbSet<MiddleSchool> MiddleSchool { get; set; }
        public virtual DbSet<MiddleSchoolMatriculateHistory> MiddleSchoolMatriculateHistory { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<ScoreSegment> ScoreSegment { get; set; }
        public virtual DbSet<SpecialMajor> SpecialMajor { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentType> StudentType { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectChoose> SubjectChoose { get; set; }
        public virtual DbSet<JiangXiAcceptance> JiangXiAcceptance { get; set; }
        public virtual DbSet<ColleageScoreLine> ColleageScoreLine { get; set; }
        public virtual DbSet<ProvinceScoreLine> ProvinceScoreLine { get; set; }

        public virtual DbSet<ColleageShortInfo> ColleageShortInfo { get; set; }

        public virtual DbSet<MajorShortInfo> MajorShortInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .Property(e => e.BatchName)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.EnrollmentPlan)
                .WithRequired(e => e.Batch1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.Batch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Choice>()
                .Property(e => e.ChoiceId)
                .IsFixedLength();

            modelBuilder.Entity<Choice>()
                .Property(e => e.ChoiceDetail)
                .IsUnicode(false);

            modelBuilder.Entity<Choice>()
                .HasMany(e => e.Grade)
                .WithRequired(e => e.Choice)
                .HasForeignKey(e => e.ChooseId1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Choice>()
                .HasMany(e => e.Grade1)
                .WithOptional(e => e.Choice1)
                .HasForeignKey(e => e.ChooseId2);

            modelBuilder.Entity<Choice>()
                .HasMany(e => e.Grade2)
                .WithOptional(e => e.Choice2)
                .HasForeignKey(e => e.ChooseId3);

            modelBuilder.Entity<Choice>()
                .HasMany(e => e.Grade3)
                .WithOptional(e => e.Choice3)
                .HasForeignKey(e => e.ChooseId3);

            modelBuilder.Entity<City>()
                .Property(e => e.CityId)
                .IsFixedLength();

            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<City>()
                .HasMany(e => e.Colleage)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.MiddleSchool)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<Colleage>()
                .Property(e => e.CityId)
                .IsFixedLength();

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageName)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageLevel)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageType)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.FamousAlumni)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.Belonging)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageKind)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageId)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleageIntro)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.CreateDate)
                .IsFixedLength();

            modelBuilder.Entity<Colleage>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.StudentCount)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .Property(e => e.ColleagezsUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.EnrollmentPlan)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.FamousTeacher)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.FinalAcceptance)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.MiddleSchoolMatriculateHistory)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colleage>()
                .HasMany(e => e.SpecialMajor)
                .WithRequired(e => e.Colleage)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ColleageShortInfo>()
               .Property(e => e.ColleageCode)
               .IsFixedLength();

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.ColleageName)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.CityId)
                .IsFixedLength();

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.ColleageType)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.ColleageLevel)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.Belonging)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageShortInfo>()
                .Property(e => e.ColleageKind)
                .IsUnicode(false);


            modelBuilder.Entity<EnrollmentPlan>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<EnrollmentPlan>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<EnrollmentPlan>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<EnrollmentPlan>()
                .Property(e => e.Batch)
                .IsUnicode(false);

            modelBuilder.Entity<EnrollmentPlan>()
                .Property(e => e.Limitations)
                .IsUnicode(false);

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.TeacherName)
                .IsUnicode(false);

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.ProfessionTitle)
                .IsUnicode(false);

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.Education)
                .IsUnicode(false);

            modelBuilder.Entity<FamousTeacher>()
                .Property(e => e.AcademicianType)
                .IsUnicode(false);

            modelBuilder.Entity<FinalAcceptance>()
                .Property(e => e.StudentId)
                .IsFixedLength();

            modelBuilder.Entity<FinalAcceptance>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<FinalAcceptance>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<Grade>()
                .Property(e => e.StudentId)
                .IsFixedLength();

            modelBuilder.Entity<Grade>()
                .Property(e => e.ChooseId1)
                .IsFixedLength();

            modelBuilder.Entity<Grade>()
                .Property(e => e.ChooseId2)
                .IsFixedLength();

            modelBuilder.Entity<Grade>()
                .Property(e => e.ChooseId3)
                .IsFixedLength();

            modelBuilder.Entity<Major>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.MajorLevel)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.MajorIntro)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.JobOrientation)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.EducationObject)
                .IsUnicode(false);


            modelBuilder.Entity<Major>()
                .Property(e => e.MainCourses)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.StudyYear)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.MajorCategoryCode)
                .IsFixedLength();

            modelBuilder.Entity<Major>()
                .Property(e => e.MajorName)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.EnrollmentPlan)
                .WithRequired(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.FamousTeacher)
                .WithRequired(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.FinalAcceptance)
                .WithRequired(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.MiddleSchoolMatriculateHistory)
                .WithRequired(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.SpecialMajor)
                .WithRequired(e => e.Major)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MajorCategory>()
                .Property(e => e.MajorCategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<MajorCategory>()
                .Property(e => e.MajorCategoryCode)
                .IsFixedLength();

            modelBuilder.Entity<MajorCategory>()
                .Property(e => e.SubjectCode)
                .IsFixedLength();

            modelBuilder.Entity<MajorCategory>()
                .HasMany(e => e.Major)
                .WithRequired(e => e.MajorCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MiddleSchool>()
                .Property(e => e.MiddleSchoolCode)
                .IsFixedLength();

            modelBuilder.Entity<MiddleSchool>()
                .Property(e => e.MiddleSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<MiddleSchool>()
                .Property(e => e.CityId)
                .IsFixedLength();

            modelBuilder.Entity<MiddleSchool>()
                .Property(e => e.IsImportant)
                .IsUnicode(false);

            modelBuilder.Entity<MiddleSchool>()
                .HasMany(e => e.MiddleSchoolMatriculateHistory)
                .WithRequired(e => e.MiddleSchool)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MiddleSchoolMatriculateHistory>()
                .Property(e => e.MiddleSchoolCode)
                .IsFixedLength();

            modelBuilder.Entity<MiddleSchoolMatriculateHistory>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<MiddleSchoolMatriculateHistory>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<MiddleSchoolMatriculateHistory>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<Province>()
                .Property(e => e.ProvinceName)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.City)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.EnrollmentPlan)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Grade)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.ScoreSegment)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<Score>()
                .Property(e => e.MajorInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<ScoreSegment>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<SpecialMajor>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<SpecialMajor>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<SpecialMajor>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentId)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.MiddleSchoolCode)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasOptional(e => e.FinalAcceptance)
                .WithRequired(e => e.Student);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Grade)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentType>()
                .Property(e => e.StudentTypeDetail)
                .IsUnicode(false);

            modelBuilder.Entity<StudentType>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.StudentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectCode)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.MajorCategory)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectChoose>()
                .Property(e => e.SubjectDetail)
                .IsUnicode(false);

            modelBuilder.Entity<SubjectChoose>()
                .HasMany(e => e.Grade)
                .WithRequired(e => e.SubjectChoose)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectChoose>()
                .HasMany(e => e.ScoreSegment)
                .WithRequired(e => e.SubjectChoose)
                .HasForeignKey(e => e.StudentTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JiangXiAcceptance>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<JiangXiAcceptance>()
                .Property(e => e.ColleageName)
                .IsUnicode(false);

            modelBuilder.Entity<JiangXiAcceptance>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<JiangXiAcceptance>()
                .Property(e => e.Batch)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageScoreLine>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<ColleageScoreLine>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<ProvinceScoreLine>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();


            modelBuilder.Entity<MajorShortInfo>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<MajorShortInfo>()
                .Property(e => e.MajorName)
                .IsUnicode(false);

            modelBuilder.Entity<MajorShortInfo>()
                .Property(e => e.MajorCategoryCode)
                .IsFixedLength();

            modelBuilder.Entity<MajorShortInfo>()
                .Property(e => e.MajorLevel)
                .IsUnicode(false);
        }
    }
}
