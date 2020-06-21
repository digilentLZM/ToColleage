using System.Data.Entity;
using System.Diagnostics;
using DaChuang.Models;

namespace DaChuang.DAL
{
    public partial class DaChuangContext : DbContext
    {
        public DaChuangContext()
            : base("name=DaChuang")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Colleage> Colleage { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MajorCategory> MajorCategory { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ColleageMajorLine> ColleageMajorLine { get; set; }
        public virtual DbSet<ScoreSegment> ScoreSegment { get; set; }
       
        public virtual DbSet<StudentType> StudentType { get; set; }
       
        public virtual DbSet<ColleageScoreLine> ColleageScoreLine { get; set; }
        public virtual DbSet<ProvinceScoreLine> ProvinceScoreLine { get; set; }
        public virtual DbSet<ColleageShortInfo> ColleageShortInfo { get; set; }
        public virtual DbSet<MajorShortInfo> MajorShortInfo { get; set; }
        public virtual DbSet<ColleageMajor> ColleageMajor { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .Property(e => e.BatchName)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.Batch)
                .WillCascadeOnDelete(false);

           

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
                .HasMany(e => e.Score)
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

            modelBuilder.Entity<ColleageMajorLine>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<ColleageMajorLine>()
                .Property(e => e.MajorCode)
                .IsUnicode(false);

            modelBuilder.Entity<ColleageMajorLine>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<ScoreSegment>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            modelBuilder.Entity<StudentType>()
                .Property(e => e.StudentTypeDetail)
                .IsUnicode(false);

            modelBuilder.Entity<StudentType>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.StudentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ColleageScoreLine>()
                .Property(e => e.ColleageCode)
                .IsFixedLength();

            modelBuilder.Entity<ColleageScoreLine>()
                .Property(e => e.ProvinceId)
                .IsFixedLength();

            //modelBuilder.Entity<ColleageScoreLine>()
            //   .Property(e => e.Average)
            //   .HasColumnType("decimal(5,2)");

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

        public System.Data.Entity.DbSet<DaChuang.Models.Subject> Subjects { get; set; }
    }
}
