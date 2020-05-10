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
    public class ColleageScoreLinesController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: ColleageScoreLines
        //筛选条件 大学名称 招生地址 考生类别 年份 录取批次 平均分 最低分 
        public ActionResult Index(int? page, string colleagename, string provinceid, int? studenttypeid, int? batchid, int? select_year)
        {
            var colleageScoreLines = db.ColleageScoreLine.AsNoTracking().Include(c => c.Batch).Include(c => c.Colleage).Include(c => c.Province).Include(c => c.StudentType);

            //这次的筛选条件存储在ViewBag中
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
            ViewBag.SchoolName = colleagename;
            ViewBag.Province = provinceid;
            ViewBag.StudentType = studenttypeid;
            ViewBag.Batch = batchid;
            ViewBag.Year = select_year;

            if (!String.IsNullOrEmpty(colleagename))//学校名称
            {
                colleageScoreLines = colleageScoreLines.AsNoTracking().Where(s => s.Colleage.ColleageName.Contains(colleagename));
            }

            if (!String.IsNullOrEmpty(provinceid))//省份 
            {
                colleageScoreLines = colleageScoreLines.AsNoTracking().Where(s => s.ProvinceId == provinceid);
            }

            if (studenttypeid != null)//学生类别 
            {
                colleageScoreLines = colleageScoreLines.AsNoTracking().Where(s => s.StudentTypeId == studenttypeid);
            }

            if (batchid != null)//批次
            {
                colleageScoreLines = colleageScoreLines.AsNoTracking().Where(s => s.BatchId == batchid);
            }

            if (select_year != null)//年份
            {
                colleageScoreLines = colleageScoreLines.AsNoTracking().Where(s => s.Year == select_year);
            }

            //分页
            int pageSize = 20; //定义每页显示的数量
            int pageNumber = page ?? 1;//if page == null then page = 1 else page
            colleageScoreLines = colleageScoreLines.OrderBy(s => s.ProvinceId);
            return View(colleageScoreLines.ToPagedList(pageNumber, pageSize));
        }

        // GET: ColleageScoreLines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageScoreLine colleageScoreLine = db.ColleageScoreLine.Find(id);
            if (colleageScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(colleageScoreLine);
        }

        // GET: ColleageScoreLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColleageScoreLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColleageCode,ProvinceId,StudentTypeId,Year,BatchId,MinScore,Average,BatchScore")] ColleageScoreLine colleageScoreLine)
        {
            if (ModelState.IsValid)
            {
                db.ColleageScoreLine.Add(colleageScoreLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colleageScoreLine);
        }

        // GET: ColleageScoreLines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageScoreLine colleageScoreLine = db.ColleageScoreLine.Find(id);
            if (colleageScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(colleageScoreLine);
        }

        // POST: ColleageScoreLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColleageCode,ProvinceId,StudentTypeId,Year,BatchId,MinScore,Average,BatchScore")] ColleageScoreLine colleageScoreLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colleageScoreLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colleageScoreLine);
        }

        // GET: ColleageScoreLines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageScoreLine colleageScoreLine = db.ColleageScoreLine.Find(id);
            if (colleageScoreLine == null)
            {
                return HttpNotFound();
            }
            return View(colleageScoreLine);
        }

        // POST: ColleageScoreLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ColleageScoreLine colleageScoreLine = db.ColleageScoreLine.Find(id);
            db.ColleageScoreLine.Remove(colleageScoreLine);
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
