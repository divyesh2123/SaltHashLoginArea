using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication22.ViewModal;

namespace WebApplication22.Controllers
{
    public class EmployeerController : Controller
    {
        // GET: Employeer
        public ActionResult Index()
        {
            var d = new List<MyJobData>();
            d = MyHelper.Helper.JobData();
            return View(d);
        }
    }
}