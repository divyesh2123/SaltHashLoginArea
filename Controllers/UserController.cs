using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication22.Models;
using WebApplication22.ViewModal;

namespace WebApplication22.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModal user)
        {
            if(!ModelState.IsValid)
            {

                return View(user);
            }

            return View();
        }


        public ActionResult ListJobData()
        {

            var d = new List<MyJobData>();
            d = MyHelper.Helper.JobData();


            return PartialView("_ListJobData", d);

        }



    }
}