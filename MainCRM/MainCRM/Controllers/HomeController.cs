using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainCRM.Controllers
{
    public class HomeController : Controller
    {
        niitcarev2Entities db = new niitcarev2Entities();
        public ActionResult Index()
        {
            ViewData["Active"] = (from o in db.Biddings
                                   where o.BiddingStage == "Stage1" & o.BiddingStatus=="Active"
                                   select o).Count();
            ViewData["Allowed"] = (from o in db.Biddings
                                  where o.BiddingStage == "Stage1" & o.BiddingStatus == "Allowed"
                                  select o).Count();
            ViewData["Pending"] = (from o in db.Biddings
                                  where o.BiddingStage == "Stage1" & o.BiddingStatus == "Pending"
                                  select o).Count();
            ViewData["Failed"] = (from o in db.Biddings
                                   where o.BiddingStage == "Stage1" & o.BiddingStatus == "Failed"
                                   select o).Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}