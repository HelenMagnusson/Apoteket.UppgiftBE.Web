using System.Collections.Generic;
using Apoteket.UppgiftBE.Web.Models;

namespace Apoteket.UppgiftBE.Web.Data
{
	public interface IBasket
	{
		List<Product> GetProducts();
		void AddProduct(int itemId);
		void RemoveProduct(int itemId);
		string Checkout();
	}

	public class Basket : IBasket
	{
		private ApotekContext db = new ApotekContext();

		// static list allows me to preserve the list data
		public static List<Product> basket = new List<Product>();

		public List<Product> GetProducts()
		{
			// Get from db using Entity Framework or linq2db (https://github.com/linq2db/linq2db)
			return basket;
		}

		public void AddProduct(int productId)
		{
            // Get from db using Entity Framework or linq2db (https://github.com/linq2db/linq2db)
            basket.Add( db.Products.Find(productId));


		}

		public void RemoveProduct(int productId)
		{
			// Get from db using Entity Framework or linq2db (https://github.com/linq2db/linq2db)
			basket.Remove(db.Products.Find(productId));
		}

		public string Checkout()
		{
			// Checkout the basket and return the id provided by order service
			return "";
		}
	}
}