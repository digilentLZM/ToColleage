using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DaChuang.DAL;
using DaChuang.Models;
using PagedList;

namespace DaChuang.Controllers
{
    public class MajorsController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        //[Route("Majors/Index/{page}/{majorLevel}/{searchString}")]
        public ActionResult Index(int? page, string majorLevel, string searchString)
        {
            var majors = db.MajorShortInfo.AsNoTracking().Include(c => c.MajorCategory);

            var levelList = new List<string>
            {
                "本科",
                "专科"
            };

            ViewBag.majorLevel = new SelectList(levelList);
            ViewBag.search = searchString;
            ViewBag.level = majorLevel;

            if (!String.IsNullOrEmpty(majorLevel))
            {
                majors = majors.Where(x => x.MajorLevel == majorLevel);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                majors = majors.Where(s => s.MajorName.Contains(searchString));
            }

            //分页
            int pageSize = 15; //定义每页显示的专业数量
            int pageNumber = (page ?? 1);//if page == null then page = 1 else page
            majors = majors.OrderBy(s => s.MajorCode);
            return View(majors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Majors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = db.Major.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // GET: Majors/Create
        public ActionResult Create()
        {
            ViewBag.MajorCategoryCode = new SelectList(db.MajorCategory, "MajorCategoryCode", "MajorCategoryName");
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajorCode,PostGraduateRate,JobRate,MajorLevel,MajorIntro,JobOrientation,EducationObject,EducationRequireMent,MainCourses,StudyYear,Degree,MajorCategoryCode,MajorName")] Major major)
        {
            if (ModelState.IsValid)
            {
                db.Major.Add(major);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorCategoryCode = new SelectList(db.MajorCategory, "MajorCategoryCode", "MajorCategoryName", major.MajorCategoryCode);
            return View(major);
        }

        // GET: Majors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = db.Major.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorCategoryCode = new SelectList(db.MajorCategory, "MajorCategoryCode", "MajorCategoryName", major.MajorCategoryCode);
            return View(major);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajorCode,PostGraduateRate,JobRate,MajorLevel,MajorIntro,JobOrientation,EducationObject,EducationRequireMent,MainCourses,StudyYear,Degree,MajorCategoryCode,MajorName")] Major major)
        {
            if (ModelState.IsValid)
            {
                db.Entry(major).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorCategoryCode = new SelectList(db.MajorCategory, "MajorCategoryCode", "MajorCategoryName", major.MajorCategoryCode);
            return View(major);
        }

        // GET: Majors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Major major = db.Major.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Major major = db.Major.Find(id);
            db.Major.Remove(major);
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
