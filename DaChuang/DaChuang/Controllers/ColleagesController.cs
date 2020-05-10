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
    public class ColleagesController : Controller
    {
        private DaChuangContext db = new DaChuangContext();

        // GET: Colleages
        //加入筛选功能 页数 所在地 学校水平 学校类型 办学类型
        public ActionResult Index(int? page, string provinceid, string colleagelevel, string colleagetype, string colleagekind)
        {
            var colleage =   db.ColleageShortInfo.AsNoTracking().Include(c => c.City.Province); //预先加载

            //先筛选后分页
            var levelList = new List<string>();
            var kindList = new List<string>();
            var typeList = new List<string>();


            ViewBag.provinceid = new SelectList(db.Province, "ProvinceId", "ProvinceName");

            levelList.Add("985");
            levelList.Add("211");
            levelList.Add("双一流");
            ViewBag.colleagelevel = new SelectList(levelList);

            kindList.Add("本科");
            kindList.Add("专科");
            ViewBag.colleagekind = new SelectList(kindList);

            typeList.Add("理工类");
            typeList.Add("师范类");
            typeList.Add("综合类");
            ViewBag.colleagetype = new SelectList(typeList);


            ViewBag.province = provinceid;
            ViewBag.level = colleagelevel;
            ViewBag.kind = colleagekind;
            ViewBag.type = colleagetype;

            if (!String.IsNullOrEmpty(provinceid))
            {
                colleage = colleage.AsNoTracking().Where(s => s.City.Province.ProvinceId == provinceid);
            }

            if (!String.IsNullOrEmpty(colleagelevel))
            {
                colleage = colleage.AsNoTracking().Where(s => s.ColleageLevel.Contains(colleagelevel));
            }
            if (!String.IsNullOrEmpty(colleagetype))
            {
                colleage = colleage.AsNoTracking().Where(s => s.ColleageType.Contains(colleagetype));
            }
            if (!String.IsNullOrEmpty(colleagekind))
            {
                colleage = colleage.AsNoTracking().Where(s => s.ColleageKind.Contains(colleagekind));
            }

            //分页
            int pageSize = 20; //定义每页显示的学校数量
            int pageNumber = (page ?? 1);//if page == null then page = 1 else page
            colleage = colleage.OrderBy(s => s.ColleageName);

            return View(colleage.ToPagedList(pageNumber, pageSize));
        }

        // GET: Colleages/Details/5
        //学校详情
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleage colleage = db.Colleage.Find(id);
            if (colleage == null)
            {
                return HttpNotFound();
            }
            return View(colleage);
        }


        // GET: Colleages/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.City, "CityId", "CityName");
            return View();
        }

        // POST: Colleages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColleageCode,CityId,ColleageName,ShortName,ColleageUrl,ColleageLevel,ColleageType,MasterCount,DoctorCount,Address,PostgraduateRate,JobRate,FamousAlumni,Belonging,ColleageKind,ColleageId,ColleageIntro,CreateDate,ColleageArea,Phone,LabCount,ImportantSubject,StudentCount,ColleagezsUrl,AcademicianCount")] Colleage colleage)
        {
            if (ModelState.IsValid)
            {
                db.Colleage.Add(colleage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.City, "CityId", "CityName", colleage.CityId);
            return View(colleage);
        }

        // GET: Colleages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleage colleage = db.Colleage.Find(id);
            if (colleage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.City, "CityId", "CityName", colleage.CityId);
            return View(colleage);
        }

        // POST: Colleages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColleageCode,CityId,ColleageName,ShortName,ColleageUrl,ColleageLevel,ColleageType,MasterCount,DoctorCount,Address,PostgraduateRate,JobRate,FamousAlumni,Belonging,ColleageKind,ColleageId,ColleageIntro,CreateDate,ColleageArea,Phone,LabCount,ImportantSubject,StudentCount,ColleagezsUrl,AcademicianCount")] Colleage colleage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colleage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.City, "CityId", "CityName", colleage.CityId);
            return View(colleage);
        }

        // GET: Colleages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleage colleage = db.Colleage.Find(id);
            if (colleage == null)
            {
                return HttpNotFound();
            }
            return View(colleage);
        }

        // POST: Colleages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Colleage colleage = db.Colleage.Find(id);
            db.Colleage.Remove(colleage);
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
