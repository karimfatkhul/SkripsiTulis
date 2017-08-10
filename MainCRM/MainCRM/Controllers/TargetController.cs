using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainCRM;
using MainCRM.DAL;

namespace MainCRM.Controllers
{
    public class TargetController : Controller
    {
        private niitcarev2Entities db = new niitcarev2Entities();

        // GET: Target
        public ActionResult Index()
        {
            var departements = db.Departements.Include(d => d.Instance);
            return View(departements.ToList());
        }
        //GET:Instance
        public ActionResult Instances()
        {

            Target viewModel = new Target();
            viewModel.Departs = db.Departements.Include(d => d.Instance);
            viewModel.Instans = db.Instances;
            return View(viewModel);

        }
        //GET:Departement
        public ActionResult Departements()
        {
            Target viewModel = new Target();
            viewModel.Departs = db.Departements.Include(d => d.Instance);
            viewModel.Instans = db.Instances;
            return View(viewModel);

        }

        // GET: Target/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // GET: Target/Create
        public ActionResult Create()
        {
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName");
            return View();
        }

        // POST: Target/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartementID,DepartementName,InstanceID,KeyContactName,KeyContactEmail,KeyContactPhone,NumberOfStudent")] Departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Departements.Add(departement);
                db.SaveChanges();
                return RedirectToAction("Departements");
            }

            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", departement.InstanceID);
            return View(departement);
        }

        // GET: Target/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", departement.InstanceID);
            return View(departement);
        }

        // POST: Target/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartementID,DepartementName,InstanceID,KeyContactName,KeyContactEmail,KeyContactPhone,NumberOfStudent")] Departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Departements");
            }
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", departement.InstanceID);
            return View(departement);
        }

        // GET: Target/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        // POST: Target/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departement departement = db.Departements.Find(id);
            db.Departements.Remove(departement);
            db.SaveChanges();
            return RedirectToAction("Departements");
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
