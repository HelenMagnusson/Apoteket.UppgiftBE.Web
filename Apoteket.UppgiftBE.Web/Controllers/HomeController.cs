using System.Collections.Generic;
using System.Web.Mvc;
using Apoteket.UppgiftBE.Web.Data;
using Apoteket.UppgiftBE.Web.Repositories;

namespace Apoteket.UppgiftBE.Web.Controllers
{
	public class HomeController : Controller
	{
		readonly IProductList _productList;
		private readonly IUnitOfWork uow;

		public HomeController(IProductList productList, IUnitOfWork uow)
		{
			_productList = productList;
			this.uow = uow;
		}

		public ActionResult Index()
		{
			// Lista de produkter som finns i _productList
			var model=uow.ProductRepository.GetAllProducts();
			return View(model);
		}
		public ActionResult Index2(Basket b)
		{
			// Lista de produkter som finns i _productList
			var model = uow.ProductRepository.GetAllProducts();
			return View(model);
		}
	}
}