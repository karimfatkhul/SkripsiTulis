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
    public class ModulController : Controller
    {
        private niitcarev2Entities db = new niitcarev2Entities();

        // GET: Modul
        public ActionResult Index()
        {
            var moduls = db.Moduls.Include(m => m.Program);
            return View(moduls.ToList());
        }
        public ActionResult Programs()
        {
            Progs viewModel = new Progs();
            viewModel.Moduls = db.Moduls.Include(d => d.Program);
            viewModel.Programs = db.Programs;
            return View(viewModel);
        }
        public ActionResult Moduls()
        {
            Progs viewModel = new Progs();
            viewModel.Moduls = db.Moduls.Include(d => d.Program);
            viewModel.Programs = db.Programs;
            return View(viewModel);
        }


        // GET: Modul/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Modul/Create
        public ActionResult Create()
        {
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            return View();
        }

        // POST: Modul/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModulID,ProgramID,ModulTitle")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduls.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Moduls");
            }

            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", modul.ProgramID);
            return View(modul);
        }

        // GET: Modul/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", modul.ProgramID);
            return View(modul);
        }

        // POST: Modul/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModulID,ProgramID,ModulTitle")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Moduls");
            }
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", modul.ProgramID);
            return View(modul);
        }

        // GET: Modul/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Modul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Moduls.Find(id);
            db.Moduls.Remove(modul);
            db.SaveChanges();
            return RedirectToAction("Moduls");
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
