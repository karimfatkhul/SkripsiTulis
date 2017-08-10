using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainCRM;

namespace MainCRM.Controllers
{
    public class BiddingController : Controller
    {
        private niitcarev2Entities db = new niitcarev2Entities();

        // GET: Bidding
        public ActionResult Index()
        {
            var biddings = db.Biddings.Include(b => b.Departement).Include(b => b.Instance).Include(b => b.Modul).Include(b => b.Program);
            return View(biddings.ToList());
        }

        // GET: Bidding/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidding bidding = db.Biddings.Find(id);
            if (bidding == null)
            {
                return HttpNotFound();
            }
            return View(bidding);
        }

        public JsonResult GetDepartement(int? id)
        {
            //Departement bid = new Departement();
            ViewBag.DepartementID = from s in db.Departements where s.InstanceID == id select s;
            return Json(new SelectList(ViewBag.DepartementID, "DepartementID", "DepartementName"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetModul(int? id)
        {
            //Departement bid = new Departement();
            ViewBag.ModuleID = from s in db.Moduls where s.ProgramID == id select s;
            return Json(new SelectList(ViewBag.ModulID, "ModulID", "ModuleTitle"), JsonRequestBehavior.AllowGet);
        }

        // GET: Bidding/Create
        public ActionResult Create()
        {
            ViewBag.DepartementID = new SelectList(db.Departements, "DepartementID", "DepartementName");
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName");
            ViewBag.ModulID = new SelectList(db.Moduls, "ModulID", "ModulTitle");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            return View();
        }

        // POST: Bidding/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BiddingID,InstanceID,DepartementID,ProgramID,ModulID,BiddingStatus,BiddingInformationDetail,BiddingStage,DateOfCurrentBidStatus,NextStep,DateOfNextStep,Qualified")] Bidding bidding)
        {
            if (ModelState.IsValid)
            {
                db.Biddings.Add(bidding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartementID = new SelectList(db.Departements, "DepartementID", "DepartementName", bidding.DepartementID);
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", bidding.InstanceID);
            ViewBag.ModulID = new SelectList(db.Moduls, "ModulID", "ModulTitle", bidding.ModulID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", bidding.ProgramID);
            return View(bidding);
        }

        // GET: Bidding/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidding bidding = db.Biddings.Find(id);
            if (bidding == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartementID = new SelectList(db.Departements, "DepartementID", "DepartementName", bidding.DepartementID);
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", bidding.InstanceID);
            ViewBag.ModulID = new SelectList(db.Moduls, "ModulID", "ModulTitle", bidding.ModulID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", bidding.ProgramID);
            return View(bidding);
        }

        // POST: Bidding/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BiddingID,InstanceID,DepartementID,ProgramID,ModulID,BiddingStatus,BiddingInformationDetail,BiddingStage,DateOfCurrentBidStatus,NextStep,DateOfNextStep,Qualified")] Bidding bidding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bidding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartementID = new SelectList(db.Departements, "DepartementID", "DepartementName", bidding.DepartementID);
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", bidding.InstanceID);
            ViewBag.ModulID = new SelectList(db.Moduls, "ModulID", "ModulTitle", bidding.ModulID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", bidding.ProgramID);
            return View(bidding);
        }

        // GET: Bidding/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidding bidding = db.Biddings.Find(id);
            if (bidding == null)
            {
                return HttpNotFound();
            }
            return View(bidding);
        }

        // POST: Bidding/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bidding bidding = db.Biddings.Find(id);
            db.Biddings.Remove(bidding);
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
