using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class OrderProController : Controller
    {
        // GET: OrderPro
        GoatSneakerEntities database = new GoatSneakerEntities();
        public ActionResult Index()
        {
            return View(database.OrderProes.ToList());
        }
		//Details
		public ActionResult Details(int id)
		{
			return View(database.OrderProes.Where(s => s.ID == id).FirstOrDefault());
		}
		//Edit
		public ActionResult Edit(int id)
		{
			return View(database.OrderProes.Where(s => s.ID == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Edit(int id, OrderPro orderpro)
		{
			database.Entry(orderpro).State = System.Data.Entity.EntityState.Modified;
			database.SaveChanges();
			return RedirectToAction("Index");
		}
		//Delete
		public ActionResult Delete(int id)
		{
			return View(database.OrderProes.Where(s => s.ID == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Delete(int id, OrderPro orderpro)
		{
			try
			{
				orderpro = database.OrderProes.Where(s => s.ID == id).FirstOrDefault();
				database.OrderProes.Remove(orderpro);
				database.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return Content("Dữ liệu này đang sử dụng trong bảng khác, xoá dữ liệu thất bại!");
			}
		}
	}
}