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
    public class InstanceController : Controller
    {
        private niitcarev2Entities db = new niitcarev2Entities();

        // GET: Instance
        public ActionResult Index()
        {
            return View(db.Instances.ToList());
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

        // GET: Instance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // GET: Instance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstanceID,InstanceName,InstanceAddress,InstanceEmail,InstancePhone")] Instance instance)
        {
            if (ModelState.IsValid)
            {
                db.Instances.Add(instance);
                db.SaveChanges();
                return RedirectToAction("Instances","Target");
            }

            return View(instance);
        }

        // GET: Instance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // POST: Instance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstanceID,InstanceName,InstanceAddress,InstanceEmail,InstancePhone")] Instance instance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Instances", "Target");
            }
            return View(instance);
        }

        // GET: Instance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // POST: Instance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instance instance = db.Instances.Find(id);
            db.Instances.Remove(instance);
            db.SaveChanges();
            return RedirectToAction("Instances", "Target");
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
