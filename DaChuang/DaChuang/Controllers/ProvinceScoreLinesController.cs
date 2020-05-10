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
    public class ProvinceScoreLinesController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: ProvinceScoreLines
        //筛选条件：省份 录取批次 考生类别 年份
        public ActionResult Index(int? page, string provinceid, int? batchid, int? studenttypeid, int? select_year)
        {
            var provinceScoreLines = db.ProvinceScoreLine.AsNoTracking().Include(p => p.Batch).Include(p => p.Province).Include(p => p.StudentType);

            //将筛选条件存储在ViewBag中
            ViewBag.studenttypeid = new SelectList(db.StudentType, "StudentTypeId", "StudentTypeDetail");
            ViewBag.provinceid = new SelectList(db.Province, "ProvinceId", "ProvinceName");
            ViewBag.batchid = new SelectList(db.Batch, "BatchId", "BatchName");
            var yearlist = new List<int>
            {
                2018,
                2017,
                2016,
                2015,
                2014,
            };
            ViewBag.select_year = new SelectList(yearlist);

            //加载选择项
            ViewBag.Province = provinceid;
            ViewBag.StudentType = studenttypeid;
            ViewBag.Batch = batchid;
            ViewBag.Year = select_year;

            if (!String.IsNullOrEmpty(provinceid))//省份 
            {
                provinceScoreLines = provinceScoreLines.AsNoTracking().Where(s => s.ProvinceId == provinceid);
            }

            if (studenttypeid != null)//学生类别 
            {
                provinceScoreLines = provinceScoreLines.AsNoTracking().Where(s => s.StudentTypeId == studenttypeid);
            }

            if (batchid != null)//批次
            {
                provinceScoreLines = provinceScoreLines.AsNoTracking().Where(s => s.BatchId == batchid);
            }

            if (select_year != null)//年份
            {
                provinceScoreLines = provinceScoreLines.AsNoTracking().Where(s => s.Year == select_year);
            }

            //分页
            int pageSize = 20; //定义每页显示的数量
            int pageNumber = page ?? 1;//if page == null then page = 1 else page
            provinceScoreLines = provinceScoreLines.OrderByDescending(s => s.Year);
            return View(provinceScoreLines.ToPagedList(pageNumber, pageSize));
        }


        // GET: ProvinceScoreLines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinceScoreLine provinceScoreLine = db.ProvinceScoreLine.Find(id);
            if (provinceScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(provinceScoreLine);
        }

        // GET: ProvinceScoreLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinceScoreLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinceId,BatchId,StudentTypeId,Year,BatchScore")] ProvinceScoreLine provinceScoreLine)
        {
            if (ModelState.IsValid)
            {
                db.ProvinceScoreLine.Add(provinceScoreLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provinceScoreLine);
        }

        // GET: ProvinceScoreLines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinceScoreLine provinceScoreLine = db.ProvinceScoreLine.Find(id);
            if (provinceScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(provinceScoreLine);
        }

        // POST: ProvinceScoreLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinceId,BatchId,StudentTypeId,Year,BatchScore")] ProvinceScoreLine provinceScoreLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provinceScoreLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provinceScoreLine);
        }

        // GET: ProvinceScoreLines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinceScoreLine provinceScoreLine = db.ProvinceScoreLine.Find(id);
            if (provinceScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(provinceScoreLine);
        }

        // POST: ProvinceScoreLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProvinceScoreLine provinceScoreLine = db.ProvinceScoreLine.Find(id);
            db.ProvinceScoreLine.Remove(provinceScoreLine);
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
