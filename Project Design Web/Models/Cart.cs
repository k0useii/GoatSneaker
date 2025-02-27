﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Design_Web.Models
{
	public class Cart
	{
		public int ID { get; set; }
		List<CartItem> items = new List<CartItem>();
		public IEnumerable<CartItem> Items
		{
			get { return items; }
		}

		public void Add_Product_Cart(Product _pro, int _quan = 1)
		{
			var item = Items.FirstOrDefault(s => s._product.ProductID == _pro.ProductID);
			if (item == null)
				items.Add(new CartItem
				{
					_product = _pro,
					_quantity = _quan
				});
			else
				item._quantity += _quan;
		}
		public int Total_quantity()
		{
			return items.Sum(s => s._quantity);
		}
		public decimal Total_money()
		{
			var total = items.Sum(s => s._quantity * s._product.Price);
			return (decimal)total;
		}
		public void Update_quantity(int id, int _new_quan)
		{
			var item = items.Find(s => s._product.ProductID == id);
			if (item != null)
			{
				if (items.Find(s => s._product.Quantity > _new_quan) != null)
					item._quantity = _new_quan;
				else
					item._quantity = 1;
			}
				
		}
		public void Remove_CartItem(int id)
		{
			items.RemoveAll(s => s._product.ProductID == id);
		}
		public void ClearCart()
		{
			items.Clear();
		}

	}
}