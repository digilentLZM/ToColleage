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
            Database.Log = sql => Debug.Write(sql);//ต๗สิ
        }

        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Colleage> Colleage { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MajorCategory> MajorCategory { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ColleageScore> ColleageMajorLine { get; set; }
        public virtual DbSet<ScoreSegment> ScoreSegment { get; set; }
       
        public virtual DbSet<StudentType> StudentType { get; set; }
       
        public virtual DbSet<ColleageScoreLine> ColleageScoreLine { get; set; }
        public virtual DbSet<ProvinceScoreLine> ProvinceScoreLine { get; set; }
        public virtual DbSet<ColleageShortInfo> ColleageShortInfo { get; set; }
        public virtual DbSet<MajorShortInfo> MajorShortInfo { get; set; }
        public virtual DbSet<ColleageMajor> ColleageMajor { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
