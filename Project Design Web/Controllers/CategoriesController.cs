using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class CategoriesController : Controller
    {
        GoatSneakerEntities database = new GoatSneakerEntities();
        // GET: Categories
        public ActionResult ListCategory(string _name)
        {
            if (_name == null)
                return View(database.Categories.ToList());
            else
                return View(database.Categories.Where(s => s.NameCate.Contains(_name)).ToList());
        }
        
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Create(Category cate)
		{
			try
			{
				database.Categories.Add(cate);
				database.SaveChanges();
				return RedirectToAction("ListCategory");
			}
			catch
			{
				return Content("Error Create New");
			}
		}
        //Details
        public ActionResult Details(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        //Edit
        public ActionResult Edit(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Category cate)
        {
            database.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("ListCategory");
        }
        //Delete
        public ActionResult Delete(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Category cate)
        {
            try
            {
                cate = database.Categories.Where(s => s.Id == id).FirstOrDefault();
                database.Categories.Remove(cate);
                database.SaveChanges();
                return RedirectToAction("ListCategory");
            }
            catch
            {
                return Content("Dữ liệu này đang sử dụng trong bảng khác, xoá dữ liệu thất bại!");
            }
        }
	}
}