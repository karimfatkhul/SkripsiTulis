using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MainCRM.DAL;
using System.Web.Helpers;

namespace MainCRM.Controllers
{
    public class BiddingController : Controller
    {
        private niitcarev2Entities db = new niitcarev2Entities();
        private string Message = "Pesan ini";

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
            ViewBag.ModulID = from s in db.Moduls where s.ProgramID == id select s;
            return Json(new SelectList(ViewBag.ModulID, "ModulID", "ModulTitle"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatus()
        {
            //Departement bid = new Departement();
            //ViewBag.Status = from s in db.Moduls where s.ProgramID == id select s;
            return Json(new SelectList(ViewBag.ModulID, "ModulID", "ModulTitle"), JsonRequestBehavior.AllowGet);
        }

        static DateTime GetNextWeekday(DayOfWeek day)
        {
            DateTime result = DateTime.Now.AddDays(1);
            while (result.DayOfWeek != day)
                result = result.AddDays(1);
            return result;
        }
    // GET: Bidding/Create
    public ActionResult Create()
        {
            
            ViewData["Pesan"] = Message;
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
        public ActionResult Create([Bind(Include = "BiddingID,InstanceID,DepartementID,ProgramID,ModulID,BiddingStatus,BiddingInformationDetail,BiddingStage,DateOfCurrentBidStatus,NextStep,DateOfNextStep,Qualified")] Bidding bidding, string Pesan, string Sub)
        {
            ViewBag.DepartementID = new SelectList(db.Departements, "DepartementID", "DepartementName", bidding.DepartementID);
            ViewBag.InstanceID = new SelectList(db.Instances, "InstanceID", "InstanceName", bidding.InstanceID);
            if (ModelState.IsValid)
            {
                ViewData["Subject"] = Sub;
                ViewData["Pesan"] = Pesan;

                DateTime now = DateTime.Now;
                bidding.DateOfCurrentBidStatus = now;
                bidding.DateOfNextStep = now.AddDays(7);
                bidding.BiddingStage = "Stage1";
                bidding.BiddingStatus = Statusnya.Active.ToString();
                db.Biddings.Add(bidding);
                db.SaveChanges();
                try
                {
                    //Configuring webMail class to send emails  
                    //gmail smtp server  
                    WebMail.SmtpServer = "smtp.gmail.com";
                    //gmail port to send emails  
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = true;
                    //sending emails with secure protocol  
                    WebMail.EnableSsl = true;
                    //EmailId used to send emails from application  
                    WebMail.UserName = "karim.fatkhul@gmail.com";
                    WebMail.Password = "aL-fatih1945";

                    //Sender email address.  
                    WebMail.From = "karim.fatkhul@gmail.com";
                    var To = db.Instances
                                .Where(b => b.InstanceID == bidding.InstanceID)
                                .Select(c=>c.InstanceEmail)
                                .FirstOrDefault();
                    var Cc = db.Departements
                                .Where(b => b.DepartementID == bidding.DepartementID)
                                .Select(c => c.KeyContactEmail)
                                .FirstOrDefault(); ;//from s in db.Departements where s.DepartementID == bidding.DepartementID select s.KeyContactEmail;
                    //Send email  
                    WebMail.Send(to: To, subject: Sub, body: Pesan, cc: Cc, isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";

                }
                catch (Exception)
                {
                    ViewBag.Status = "Problem while sending email, Please check details.";

                }
                return RedirectToAction("Index");
            }

            
            ViewBag.ModulID = new SelectList(db.Moduls, "ModulID", "ModulTitle", bidding.ModulID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", bidding.ProgramID); 
            return View(bidding);
        }

        public ActionResult Rd(Bidding bid)
        {
            return View(bid);
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
            var  a=bidding.Stat.ToString();
            a = bidding.BiddingStatus;
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
                bidding.BiddingStatus = bidding.Stat.ToString();
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
