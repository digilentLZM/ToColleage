using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DaChuang.DAL;
using DaChuang.Models;
using PagedList;

namespace DaChuang.Controllers
{
    public class ScoreSegmentsController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: ScoreSegments
        //页数， 省份， 年份， 学生类型
        public ActionResult Index(int? page, string provinceid, int? select_year, int? studentTypeid)
        {

            ViewBag.studentTypeid = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail");
            ViewBag.provinceid = new SelectList(db.Province, "ProvinceId", "ProvinceName");
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
            ViewBag.Province = provinceid;
            ViewBag.StudentType = studentTypeid;
            ViewBag.Year = select_year;

            var scoreSegment = db.ScoreSegment.AsNoTracking().Include(s => s.StudentType).Include(s => s.Province);

            if (!String.IsNullOrEmpty(provinceid))//省份
            {
                scoreSegment = scoreSegment.Where(s => s.ProvinceId == provinceid);
            }

            if (select_year != null)//年份
            {
                scoreSegment = scoreSegment.Where(s => s.Year == select_year);
            }

            if (studentTypeid != null) //学生类型
            {
                scoreSegment = scoreSegment.Where(s => s.StudentTypeId == studentTypeid);
            }

            //分页
            int pageSize = 20; //定义每页显示的数量
            int pageNumber = page ?? 1;//if page == null then page = 1 else page
            scoreSegment = scoreSegment.OrderBy(s => s.ProvinceId).ThenByDescending(s => s.Score);
            return View(scoreSegment.ToPagedList(pageNumber, pageSize));
        }

        // GET: ScoreSegments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreSegment scoreSegment = db.ScoreSegment.Find(id);
            if (scoreSegment == null)
            {
                return HttpNotFound();
            }
            return View(scoreSegment);
        }

        // GET: ScoreSegments/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName");
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail");
            return View();
        }

        // POST: ScoreSegments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinceId,StudentTypeId,Year,Score,SegmentCount,Count")] ScoreSegment scoreSegment)
        {
            if (ModelState.IsValid)
            {
                db.ScoreSegment.Add(scoreSegment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", scoreSegment.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", scoreSegment.StudentTypeId);
            return View(scoreSegment);
        }

        // GET: ScoreSegments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreSegment scoreSegment = db.ScoreSegment.Find(id);
            if (scoreSegment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", scoreSegment.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", scoreSegment.StudentTypeId);
            return View(scoreSegment);
        }

        // POST: ScoreSegments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinceId,StudentTypeId,Year,Score,SegmentCount,Count")] ScoreSegment scoreSegment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoreSegment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", scoreSegment.ProvinceId);
            ViewBag.StudentTypeId = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail", scoreSegment.StudentTypeId);
            return View(scoreSegment);
        }

        // GET: ScoreSegments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreSegment scoreSegment = db.ScoreSegment.Find(id);
            if (scoreSegment == null)
            {
                return HttpNotFound();
            }
            return View(scoreSegment);
        }

        // POST: ScoreSegments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ScoreSegment scoreSegment = db.ScoreSegment.Find(id);
            db.ScoreSegment.Remove(scoreSegment);
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
