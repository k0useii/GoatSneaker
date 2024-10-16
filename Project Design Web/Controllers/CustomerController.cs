using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        GoatSneakerEntities database = new GoatSneakerEntities();
        public ActionResult Index()
        {
            return View(database.Customers.ToList());
        }
		//Get: Create
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Customer cus)
		{
			try
			{
				database.Customers.Add(cus);
				database.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return Content("Lỗi tạo mới khách hàng!!!");
			}
		}
		//Details
		
		public ActionResult Details(int id)
		{
			return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
		}
		//Edit
		public ActionResult Edit(int id)
		{
			return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Edit(int id, Customer cus)
		{
			database.Entry(cus).State = System.Data.Entity.EntityState.Modified;
			database.SaveChanges();
			return RedirectToAction("Index");
		}
		//Delete
		public ActionResult Delete(int id)
		{
			return View(database.Customers.Where(s => s.IDCus == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Delete(int id, Customer cus)
		{
			try
			{
				cus = database.Customers.Where(s => s.IDCus == id).FirstOrDefault();
				database.Customers.Remove(cus);
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