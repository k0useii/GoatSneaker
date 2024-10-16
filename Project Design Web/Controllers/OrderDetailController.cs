using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        GoatSneakerEntities database = new GoatSneakerEntities();
        public ActionResult Index()
        {
            return View(database.OrderDetails.ToList());
        }
		
		//Details
		public ActionResult Details(int id)
		{
			return View(database.OrderDetails.Where(s => s.ID == id).FirstOrDefault());
		}
		//Delete
		public ActionResult Delete(int id)
		{
			return View(database.OrderDetails.Where(s => s.ID == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Delete(int id, OrderDetail orderdetail)
		{
			try
			{
				orderdetail = database.OrderDetails.Where(s => s.ID == id).FirstOrDefault();
				database.OrderDetails.Remove(orderdetail);
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