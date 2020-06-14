using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DaChuang.DAL;
using DaChuang.Models;
using PagedList;

namespace DaChuang.Controllers
{
    public class ColleageMajorLinesController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: Scores
        //分页， 分数查询, 筛选条件是 学校所在地 学生类别 省份 批次 年份
        public ActionResult Index(int? page, string colleagename, string location, int? studenttypeid, string provinceid, int? batchid, int? select_year)
        {
            var scores = (from score in db.ColleageMajorLine
                          join colleage in db.Colleage on score.ColleageCode equals colleage.ColleageCode
                          join batch in db.Batch on score.BatchId equals batch.BatchId
                          join stutype in db.StudentType on score.StudentTypeId equals stutype.StudentTypeId
                          select score);

            //这次的筛选条件存储在ViewBag中
            ViewBag.location = new SelectList(db.Province, "ProvinceId", "ProvinceName");
            ViewBag.studenttypeid = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail");
            ViewBag.provinceid = ViewBag.location;
            ViewBag.batchid = new SelectList(db.Batch, "BatchId", "BatchName");
            var yearlist = new List<int>
            {
                2019,
                2018,
                2017,
                2016,
                2015,
                2014,
            };
            ViewBag.select_year = new SelectList(yearlist);

            //加载选择项
            ViewBag.SchoolName = colleagename;
            ViewBag.Area = location;
            ViewBag.StudentType = studenttypeid;
            ViewBag.Province = provinceid;
            ViewBag.Batch = batchid;
            ViewBag.Year = select_year;

            if (!String.IsNullOrEmpty(colleagename))//学校名称
            {
                scores = scores.AsNoTracking().Where(s => s.Colleage.ColleageName.Contains(colleagename));
            }

            if (!String.IsNullOrEmpty(location))//学校所在地 
            {
                scores = scores.AsNoTracking().Where(s => s.Colleage.City.Province.ProvinceId == location);
            }
            if (studenttypeid != null)//学生类别 
            {
                scores = scores.AsNoTracking().Where(s => s.StudentTypeId == studenttypeid);
            }

            if (!String.IsNullOrEmpty(provinceid))//省份 
            {
                scores = scores.AsNoTracking().Where(s => s.ProvinceId == provinceid);
            }

            if (batchid != null)//批次
            {
                scores = scores.AsNoTracking().Where(s => s.BatchId == batchid);
            }

            if (select_year != null)//年份
            {
                scores = scores.AsNoTracking().Where(s => s.Year == select_year);
            }

            scores = scores.OrderBy(s => s.ColleageCode); //按照大学代码排序

            //分页
            int pageSize = 10; //定义每页显示的数量
            int pageNumber = (page ?? 1);//if page == null then page = 1 else page
            return View(scores.ToPagedList(pageNumber, pageSize));
        }


        // GET: Scores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajorLine score = db.ColleageMajorLine.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.BatchId = new SelectList(db.Batch, "BatchId", "BatchName");
            ViewBag.ColleageCode = new SelectList(db.Colleage, "ColleageCode", "CityId");
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName");
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColleageCode,MajorCode,BatchId,ProvinceId,StudentTypeId,Year,Average,MinScore,BatchScore,AverageRank,MinRank")] ColleageMajorLine score)
        {
            if (ModelState.IsValid)
            {
                db.ColleageMajorLine.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchId = new SelectList(db.Batch, "BatchId", "BatchName", score.BatchId);
            ViewBag.ColleageCode = new SelectList(db.Colleage, "ColleageCode", "CityId", score.ColleageCode);
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", score.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", score.StudentTypeId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajorLine score = db.ColleageMajorLine.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchId = new SelectList(db.Batch, "BatchId", "BatchName", score.BatchId);
            ViewBag.ColleageCode = new SelectList(db.Colleage, "ColleageCode", "CityId", score.ColleageCode);
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", score.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", score.StudentTypeId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColleageCode,MajorCode,BatchId,ProvinceId,StudentTypeId,Year,Average,MinScore,BatchScore,AverageRank,MinRank")] ColleageMajorLine score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchId = new SelectList(db.Batch, "BatchId", "BatchName", score.BatchId);
            ViewBag.ColleageCode = new SelectList(db.Colleage, "ColleageCode", "CityId", score.ColleageCode);
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", score.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", score.StudentTypeId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajorLine score = db.ColleageMajorLine.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ColleageMajorLine score = db.ColleageMajorLine.Find(id);
            db.ColleageMajorLine.Remove(score);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
