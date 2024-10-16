using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Design_Web.Models
{
	public class CartItem
	{
		public Product _product { get; set; }
		public int _quantity { get; set; }
	}
}