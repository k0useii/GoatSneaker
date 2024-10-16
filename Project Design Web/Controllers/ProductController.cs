using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
	public class ProductController : Controller
	{
		GoatSneakerEntities database = new GoatSneakerEntities();
		// GET: Product
		public ActionResult Index()
		{
			return View(database.Products.ToList());
		}
		//Get:Product Index1
		public ActionResult ProductList()
		{
			return View(database.Products.ToList());
		}
		//Create
		public ActionResult Create()
		{
			Product pro = new Product();
			return View(pro);
		}
		[HttpPost]
		public ActionResult Create(Product pro)
		{
			try
			{
				if (pro.UploadImage != null)
				{
					string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
					filename = filename + extent;
					pro.ImagePro = "~/Image/" + filename;
					pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Image/"), filename));
				}
				database.Products.Add(pro);
				database.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
		//Select Cate
		public ActionResult SelectCate()
		{
			Category se_cate = new Category();
			se_cate.ListCate = database.Categories.ToList<Category>();
			return PartialView(se_cate);
		}

		//Search OPtion
		public ActionResult SearchOption(int? category, string SearchString, double min = double.MinValue, double max = double.MaxValue)
		{
			var products = database.Products.Include(p => p.Category);
			// Tìm kiếm chuỗi truy vấn theo category
			if (category == null)
			{
				products = database.Products.OrderByDescending(x => x.NamePro);
			}
			else
			{
				products = database.Products.OrderByDescending(x => x.Category1.Id).Where(x => x.Category1.Id == category);
			}
			// Tìm kiếm chuỗi truy vấn theo NamePro (SearchString)
			if (!String.IsNullOrEmpty(SearchString))
			{
				products = database.Products.Where(s => s.NamePro.Contains(SearchString.Trim()));
			}
			// Tìm kiếm chuỗi truy vấn theo đơn giá
			if (min >= 0 && max > 0)
			{
				products = database.Products.OrderByDescending(x => x.Price).Where(p => (double)p.Price >= min && (double)p.Price <= max);
			}
			return View(products.ToList());



		}
		
		//Details product
		public ActionResult Details(int id)
		{
			return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
		}
		//Details product
		public ActionResult Details1(int id)
		{
			return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
		}
		//Delete
		public ActionResult Delete(int id)
		{
			return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
		}
		[HttpPost]
		public ActionResult Delete(int id, Product pro)
		{
			try
			{
				pro = database.Products.Where(s => s.ProductID == id).FirstOrDefault();
				database.Products.Remove(pro);
				database.SaveChanges();
				return RedirectToAction("ProductList");
			}
			catch
			{
				return Content("Dữ liệu này đang sử dụng trong bảng khác, xoá dữ liệu thất bại!");
			}
		}

	}




}
