using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication22.Models;
using WebApplication22.MyHelper;
using WebApplication22.ViewModal;

namespace WebApplication22.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User objNewUser)
        {
            try
            {
                using (var context = new CmsDbContext())
                {
                    var chkUser = (from s in context.ObjRegisterUser where s.UserName == objNewUser.UserName || s.EmailId == objNewUser.EmailId select s).FirstOrDefault();
                    if (chkUser == null)
                    {
                        var keyNew = Helper.GeneratePassword(10);
                        var password = Helper.EncodePassword(objNewUser.Password, keyNew);
                        objNewUser.Password = password;
                        objNewUser.CreateDate = DateTime.Now;
                        objNewUser.ModifyDate = DateTime.Now;
                        objNewUser.VCode = keyNew;
                        context.ObjRegisterUser.Add(objNewUser);
                        context.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("LogIn", "Login");
                    }
                    ViewBag.ErrorMessage = "User Allredy Exixts!!!!!!!!!!";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Some exception occured" + e;
                return View();
            }

        }

            // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(LoginViewModal loginViewModal)
        {
            try
            {
                using (var context = new CmsDbContext())
                {
                    var getUser = (from s in context.ObjRegisterUser where s.UserName == loginViewModal.UserName || s.EmailId == loginViewModal.UserName select s).FirstOrDefault();
                    if (getUser != null)
                    {
                        var hashCode = getUser.VCode;
                        //Password Hasing Process Call Helper Class Method    
                        var encodingPasswordString = Helper.EncodePassword(loginViewModal.Password, hashCode);
                        //Check Login Detail User Name Or Password    
                        var query = (from s in context.ObjRegisterUser where (s.UserName == loginViewModal.UserName || s.EmailId == loginViewModal.UserName) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();
                        if (query != null)
                        {
                            //RedirectToAction("Details/" + id.ToString(), "FullTimeEmployees");    
                            //return View("../Admin/Registration"); url not change in browser    
                            return RedirectToAction("Index", "Admin");
                        }
                        ViewBag.ErrorMessage = "Invallid User Name or Password";
                        return View();
                    }
                    ViewBag.ErrorMessage = "Invallid User Name or Password";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = " Error!!! contact cms@info.in";
                return View();
            }
        }



    }
}