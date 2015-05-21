using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KuasRepair.Models;

namespace KuasRepair.Controllers
{
    public class RepairsController : Controller
    {
        private RepairDBEntities db = new RepairDBEntities();

        // GET: Repairs
        public ActionResult Index()
        {
            var repair = db.Repair.Include(r => r.Customer).Include(r => r.Employee).Include(r => r.Sort);
            return View(repair.ToList());
        }

        // GET: Repairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // GET: Repairs/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name");
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name");
            ViewBag.Sort_ID = new SelectList(db.Sort, "Sort_ID", "Sort_Name");
            return View();
        }

        // POST: Repairs/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Repair_ID,Repair_Cause,Repair_Date,Repair_Object,Repair_Finishdate,Repair_Price,Repair_Way,Employee_ID,Sort_ID,Customer_ID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Repair.Add(repair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", repair.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", repair.Employee_ID);
            ViewBag.Sort_ID = new SelectList(db.Sort, "Sort_ID", "Sort_Name", repair.Sort_ID);
            return View(repair);
        }

        // GET: Repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", repair.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", repair.Employee_ID);
            ViewBag.Sort_ID = new SelectList(db.Sort, "Sort_ID", "Sort_Name", repair.Sort_ID);
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Repair_ID,Repair_Cause,Repair_Date,Repair_Object,Repair_Finishdate,Repair_Price,Repair_Way,Employee_ID,Sort_ID,Customer_ID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", repair.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", repair.Employee_ID);
            ViewBag.Sort_ID = new SelectList(db.Sort, "Sort_ID", "Sort_Name", repair.Sort_ID);
            return View(repair);
        }

        // GET: Repairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repair.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repair repair = db.Repair.Find(id);
            db.Repair.Remove(repair);
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
