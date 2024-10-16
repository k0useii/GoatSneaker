﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class LoginUserController : Controller
    {
        GoatSneakerEntities database = new GoatSneakerEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult FormLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult LoginAcount(AdminUser _user)
		{
			var check = database.AdminUsers.Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();

			if (check == null)
			{
				ViewBag.ErrorInfo = "Sai Info";
				return View("FormLogin");
			}
			else
			{
				database.Configuration.ValidateOnSaveEnabled = false;

				Session["NameUser"] = _user.NameUser;
				return RedirectToAction("Index", "Product");
			}
		}

		public ActionResult RegisterUser()
		{
			return View();
		}
		[HttpPost]
		public ActionResult RegisterUser(AdminUser _user)
		{
			if (ModelState.IsValid)
			{
				var check_ID = database.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault();
				if (check_ID == null)
				{
					database.Configuration.ValidateOnSaveEnabled = false;
					database.AdminUsers.Add(_user);
					database.SaveChanges();
					return RedirectToAction("FormLogin");

				}
				else
				{
					ViewBag.ErrorrRegister = "ID này đã tồn tại";
					return View();
				}
			}
			return View();
		}
		public ActionResult LogOutUser()
		{
			Session.Abandon();
			return RedirectToAction("FormLogin", "LoginUser");
		}
	}
}