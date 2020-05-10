using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DaChuang.DAL;
using DaChuang.Models;

namespace DaChuang.Controllers
{
    public class ProvincesController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: Provinces
        public ActionResult Index()
        {
            return View(db.Province.ToList());
        }

        // GET: Provinces/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = db.Province.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // GET: Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinceId,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                db.Province.Add(province);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(province);
        }

        // GET: Provinces/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = db.Province.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinceId,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(province);
        }

        // GET: Provinces/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = db.Province.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Province province = db.Province.Find(id);
            db.Province.Remove(province);
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
