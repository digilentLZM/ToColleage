using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DaChuang.DAL;
using DaChuang.Models;
using PagedList;

namespace DaChuang.Controllers
{
    public class ColleageMajorsController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: ColleageMajors
        //页码 专业名称  大学名称
        public ActionResult Index(int ?page, string majorname, string colleagename, string majorcode)
        {
            var colleagemajor = db.ColleageMajor.AsNoTracking().Include(c => c.Colleage).Include(c => c.Major);

            ViewBag.MajorName = majorname;
            ViewBag.ColleageName = colleagename;
            ViewBag.MajorCode = majorcode;

            //分页
            bool IsMajorCodeEmpty = true;
            if (!String.IsNullOrEmpty(majorcode))
            {
                colleagemajor = colleagemajor.AsNoTracking().Where(s => s.Major.MajorCode == majorcode);
                IsMajorCodeEmpty = false;
            }

            if (!String.IsNullOrEmpty(majorname) && IsMajorCodeEmpty)
            {
                colleagemajor = colleagemajor.AsNoTracking().Where(s => s.Major.MajorName.Contains(majorname));
            }

            if (!String.IsNullOrEmpty(colleagename) && IsMajorCodeEmpty)
            {
                colleagemajor = colleagemajor.AsNoTracking().Where(s => s.Colleage.ColleageName == colleagename);
            }
            int pageSize = 20; //定义每页显示的数量
            int pageNumber = (page ?? 1);//if page == null then page = 1 else page

            colleagemajor = colleagemajor.OrderBy(s => s.Major.MajorName);

            return View(colleagemajor.ToPagedList(pageNumber, pageSize));
        }

        // GET: ColleageMajors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajor colleageMajor = db.ColleageMajor.Find(id);
            if (colleageMajor == null)
            {
                return HttpNotFound();
            }
            return View(colleageMajor);
        }

        // GET: ColleageMajors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColleageMajors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColleageCode,MajorCode")] ColleageMajor colleageMajor)
        {
            if (ModelState.IsValid)
            {
                db.ColleageMajor.Add(colleageMajor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colleageMajor);
        }

        // GET: ColleageMajors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajor colleageMajor = db.ColleageMajor.Find(id);
            if (colleageMajor == null)
            {
                return HttpNotFound();
            }
            return View(colleageMajor);
        }

        // POST: ColleageMajors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColleageCode,MajorCode")] ColleageMajor colleageMajor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colleageMajor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colleageMajor);
        }

        // GET: ColleageMajors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColleageMajor colleageMajor = db.ColleageMajor.Find(id);
            if (colleageMajor == null)
            {
                return HttpNotFound();
            }
            return View(colleageMajor);
        }

        // POST: ColleageMajors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ColleageMajor colleageMajor = db.ColleageMajor.Find(id);
            db.ColleageMajor.Remove(colleageMajor);
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
