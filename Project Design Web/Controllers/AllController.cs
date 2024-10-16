using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Design_Web.Models;

namespace Project_Design_Web.Controllers
{
    public class AllController : Controller
    {
        // GET: All
        GoatSneakerEntities database = new GoatSneakerEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Nike()
        {
			var nike = database.Products.Where(p => p.NamePro.Contains("Nike"));
			return View(nike);
		}
		public ActionResult Jordan()
		{
			var jordan = database.Products.Where(p => p.NamePro.Contains("Jordan"));
			return View(jordan);
		}
		public ActionResult Adidas()
		{
			var adidas = database.Products.Where(p => p.NamePro.Contains("Adidas"));
			return View(adidas);
		}
		public ActionResult Vans()
		{
			var vans = database.Products.Where(p => p.NamePro.Contains("Vans"));
			return View(vans);
		}
		public ActionResult Converse()
		{
			var converse = database.Products.Where(p => p.NamePro.Contains("Converse"));
			return View(converse);
		}
		public ActionResult Other()
		{
			var other = database.Products.Where(p => p.Price <= 60);
			return View(other);
		}
		
    }
}